using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System.Drawing;

namespace ColorProviders
{
    internal sealed class FirstFitGraphColoringProvider : IGraphSequentialColoringProvider
    {
        private readonly List<Node> nodeOrder;
        private readonly List<Color> colorOrder;

        internal FirstFitGraphColoringProvider(List<Node> nodeOrder = null, List<Color> colorOrder = null)
        {
            this.nodeOrder = nodeOrder;
            this.colorOrder = colorOrder;
        }

        public void ProvideNodeColors(Graph graph)
        {
            List<Color> colorOrder = this.GetColorOrder(graph.Size);
            List<Node> nodeOrder = this.nodeOrder ?? graph.Nodes.ToList();
            var nodeColorProvider = new FirstFitNodeColorProvider();

            foreach (Node node in nodeOrder)
                nodeColorProvider.ProvideNodeColor(graph, node, colorOrder);
        }

        private List<Color> GetColorOrder(int size)
        {
            if (this.colorOrder != null)
                return this.colorOrder;

            var randomColorProvider = new RandomColorProvider();
            return randomColorProvider.ProvideRandomColorList(size);
        }
    }
}
