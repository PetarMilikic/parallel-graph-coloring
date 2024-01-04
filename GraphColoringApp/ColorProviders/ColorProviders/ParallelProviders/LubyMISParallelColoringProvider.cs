using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System.Collections.Concurrent;
using System.Drawing;

namespace ColorProviders
{
    internal sealed class LubyMISParallelColoringProvider : IGraphParallelColoringProvider
    {
        private readonly ParallelOptions parallelOptions;
        public LubyMISParallelColoringProvider()
        {
            this.parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };
        }

        public void ProvideNodeColors(Graph graph)
        {
            this.ProvideNodePriorities(graph);
            var independentSetProvider = new PrallelMaximalIndependentSetProvider();
            Graph currentGraph = graph.GetCopy();
            var randomColorProvider = new RandomColorProvider();

            while (currentGraph.AdjacencyList.Count> 0)
            {
                HashSet<Node> maximalIndependentSet = independentSetProvider.Get(currentGraph);
                Color newColor = randomColorProvider.ProvideRandomColor();
                this.ProcessIndependentSetColoring(maximalIndependentSet, newColor);
                this.ExcludeNodesFromGraph(currentGraph, maximalIndependentSet);
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

        public void ProcessIndependentSetColoring(IEnumerable<Node> nodes, Color color)
        {
            Parallel.ForEach(nodes, this.parallelOptions, node =>
            {
                node.Color = color;
            });
        }

        private void ProvideNodePriorities(Graph graph)
        {
            int uppeIntervalrBound = graph.Size > 7000 ? int.MaxValue : (int)Math.Pow(graph.Size, 2) + 1;

            Parallel.ForEach(graph.Nodes, this.parallelOptions, node =>
            {
                Random randomizer = new Random();
                node.Priority = randomizer.Next(uppeIntervalrBound);
            });
        }
    }
}
