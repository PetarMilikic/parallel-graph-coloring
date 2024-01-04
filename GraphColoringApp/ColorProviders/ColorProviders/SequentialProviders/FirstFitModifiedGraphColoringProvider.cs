using ColorProviders.Interfaces;
using CommonProject;
using System.Drawing;
using System.Net;

namespace ColorProviders
{
    internal sealed class FirstFitModifiedGraphColoringProvider : IGraphSequentialColoringProvider
    {
        private readonly List<Color> colorOrder;
        private readonly List<Node> nodeOrder;
        private readonly int additionalNumberOfIterations;

        internal FirstFitModifiedGraphColoringProvider(List<Color> colorOrder = null, List<Node> nodeOrder = null, int additionalNumberOfIterations = 0)
        {
            this.colorOrder = colorOrder;
            this.nodeOrder = nodeOrder;
            this.additionalNumberOfIterations = additionalNumberOfIterations;
        }

        public void ProvideNodeColors(Graph graph)
        {
            List<Node> nodeOrder = this.nodeOrder;
            int previousNumberOfColors = int.MaxValue;
            int currentNumberOfColors = 0;

            int currentIterationNumber = 0;

            while (previousNumberOfColors != currentNumberOfColors || currentIterationNumber < this.additionalNumberOfIterations)
            {
                if (previousNumberOfColors == currentNumberOfColors)
                    currentIterationNumber++;

                previousNumberOfColors = graph.NodeColors.Count;
                var colorProvider = new FirstFitGraphColoringProvider(nodeOrder, this.colorOrder);
                 
                if (nodeOrder != null)
                    this.ResetNodeColors(nodeOrder);

                colorProvider.ProvideNodeColors(graph);
                currentNumberOfColors = graph.NodeColors.Count;
                nodeOrder = this.GetColoringOrderByGroups(graph);
            }
        }

        private List<Node> GetColoringOrderByGroups(Graph graph)
        {
            List<IGrouping<Color, Node>> colorGroups = (this.nodeOrder ?? graph.Nodes.ToList()).GroupBy(node => node.Color).ToList();
            var orederedNodes = new List<Node>(graph.Size);   

            foreach (IGrouping<Color, Node> group in colorGroups)
                orederedNodes.AddRange(group);

            orederedNodes.Reverse();

            return orederedNodes;
        }

        private void ResetNodeColors(List<Node> nodes)
        {
            if (nodes != null)
                foreach (Node node in nodes)
                    node.Color = Color.Empty;
        }
    }
}
