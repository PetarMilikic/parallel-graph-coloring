using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System.Drawing;

namespace ColorProviders
{
    internal sealed class MaximalIndependentSetGraphColoringProvider : IGraphSequentialColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            HashSet<Node> currentNodes = graph.Nodes.ToHashSet();
            var independentSetProvider = new MaximalIndependentSetProvider();
            var radnomColorProvider = new RandomColorProvider();
            Graph currentGraph = graph;

            while (currentNodes.Count > 0)
            {
                HashSet<Node> maximalIndependentSetOfNodes = independentSetProvider.Get(currentGraph);
                Color newColor = radnomColorProvider.ProvideRandomColor();

                foreach (Node node in maximalIndependentSetOfNodes)
                    node.Color = newColor;

                currentNodes.ExceptWith(maximalIndependentSetOfNodes);
                currentGraph = currentGraph.GetInducedSubgraph(currentNodes);
            }
        }
    }
}
