using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System.Drawing;

namespace ColorProviders
{
    internal sealed class LDOGraphColoringProvider : IGraphColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        { 
            List<Color> colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);

            var nodeColorProvider = new FirstFitNodeColorProvider();
            IEnumerable<Node> sortedNodes = graph.Nodes.OrderByDescending(node => graph.AdjacencyList[node].Count);
        
            foreach (Node node in sortedNodes)
                nodeColorProvider.ProvideNodeColor(graph, node, colorOrder);
        }
    }
}
