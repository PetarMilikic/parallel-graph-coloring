using CommonProject;
using System.Collections.Concurrent;
using System.Drawing;
using System.Xml.Linq;

namespace ColorProviders.Utiliies
{
    internal class PrallelMaximalIndependentSetProvider
    {
        private readonly ParallelOptions parallelOptions;
        private readonly object lockObject;

        internal PrallelMaximalIndependentSetProvider()
        {
            this.parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            this.lockObject = new object();
        }

        public HashSet<Node> Get(Graph graph)
        {
            Graph incudedSugrapf = graph;
            HashSet<Node> currentNodes = graph.Nodes.ToHashSet();

            Graph currentGraph = graph.GetCopy();
            var result = new HashSet<Node>();

            HashSet<Node> currentSet;

            while (currentGraph.Size > 0)
            {
                currentSet = new HashSet<Node>();

                Parallel.ForEach(currentGraph.Nodes, this.parallelOptions, node =>
                {
                    int nodeDegree = currentGraph.GetNodeDegree(node);
                    bool addNode = true;

                    foreach (Node neighbour in currentGraph.GetNodeNeighbours(node))
                    {
                        int neigbourDegree = currentGraph.GetNodeDegree(neighbour);
                        if (nodeDegree > neigbourDegree || nodeDegree == neigbourDegree && node.Priority < neighbour.Priority)
                        {
                            addNode = false;
                            break;
                        }
                    }

                    if (addNode)
                        lock (lockObject)
                        {
                            currentSet.Add(node);
                        }
                });

                result.UnionWith(currentSet);
                ConcurrentBag<Node> nodesToExclude = this.GetNodesToExclude(currentSet, currentGraph);
                this.ExcludeNodesFromGraph(currentGraph, nodesToExclude);
            }

            return result;
        }

        private ConcurrentBag<Node> GetNodesToExclude(HashSet<Node> nodes, Graph graph)
        {
            var nodesToExclude = new ConcurrentBag<Node>();

            Parallel.ForEach(nodes, this.parallelOptions, node =>
            {
                nodesToExclude.Add(node);

                foreach (var neighbour in graph.AdjacencyList[node])
                {
                    nodesToExclude.Add(neighbour);
                }
            });

            return nodesToExclude;

        }

        private void ExcludeNodesFromGraph(Graph graph, ConcurrentBag<Node> nodesToExclude)
        {
            Parallel.ForEach(nodesToExclude, this.parallelOptions, node =>
            {
                graph.AdjacencyList.Remove(node, out _);
            });

            Parallel.ForEach(graph.AdjacencyList, this.parallelOptions, edge =>
            {
                edge.Value.ExceptWith(nodesToExclude);
            });
        }
    }
}
