using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System.Collections.Concurrent;
using System.Drawing;

namespace ColorProviders
{
    internal sealed class JonesPlassmanLDFColorProvider : IGraphParallelColoringProvider
    {
        private readonly object lockObject;
        private readonly ParallelOptions parallelOptions;
        public JonesPlassmanLDFColorProvider()
        {
            this.lockObject = new object();

            this.parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
        }

        public void ProvideNodeColors(Graph graph)
        {
            List<Color> colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);
            this.ProvideNodePriorities(graph);
            HashSet<Node> currentNodeSet = graph.Nodes.ToHashSet();
            Graph currentGraph = graph.GetCopy();

            while (currentGraph.AdjacencyList.Count > 0) 
            {
                var independentSet = new HashSet<Node>();
                Parallel.ForEach(currentGraph.Nodes, this.parallelOptions, node =>
                {
                    int nodeDegree = currentGraph.GetNodeDegree(node);
                    bool addNode = true;

                    foreach (Node neighbour in currentGraph.GetNodeNeighbours(node))
                    {
                        int neigbourDegree = currentGraph.GetNodeDegree(neighbour);
                        if (nodeDegree <  neigbourDegree || nodeDegree == neigbourDegree && node.Priority < neighbour.Priority)
                        {
                            addNode = false;
                            break;
                        }
                    }

                    if (addNode)
                        lock (lockObject)
                        {
                            independentSet.Add(node);
                        }
                });

                Parallel.ForEach(independentSet, this.parallelOptions, node =>
                {
                    var nodeColorProvider = new FirstFitNodeColorProvider();
                    nodeColorProvider.ProvideNodeColor(graph, node, colorOrder);
                });

                this.ExcludeNodesFromGraph(currentGraph, independentSet);
            }
        }

        private void ExcludeNodesFromGraph(Graph graph, HashSet<Node> nodesToExclude)
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

        private void ProvideNodePriorities(Graph graph)
        {
            int uppeIntervalBound = graph.Size > 7000 ? int.MaxValue : (int)Math.Pow(graph.Size, 2) + 1;

            Parallel.ForEach(graph.Nodes, this.parallelOptions, node => 
            {
                Random randomizer = new Random();
                node.Priority = randomizer.Next(uppeIntervalBound);
            });
        }
    }
}
