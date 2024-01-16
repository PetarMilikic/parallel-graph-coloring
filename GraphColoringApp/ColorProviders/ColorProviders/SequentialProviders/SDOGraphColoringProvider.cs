using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;

namespace ColorProviders
{
    internal sealed class SDOGraphColoringProvider : IGraphSequentialColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            var colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);
            var nodeColorProvider = new FirstFitNodeColorProvider();
            HashSet<Node> currentNodes = graph.Nodes.ToHashSet();
            var coloredNodes = new HashSet<Node>();
            Node maxSaturationDegreeNode;

            while (currentNodes.Count > 0)
            {
                maxSaturationDegreeNode = null;
                int maxSaturationDegree = -1;

                foreach (Node node in currentNodes)
                {
                    int saturationDegree = this.CalculateSaturationDegree(node, graph, coloredNodes);
                    if (saturationDegree > maxSaturationDegree)
                    {
                        maxSaturationDegreeNode = node;
                        maxSaturationDegree = saturationDegree;
                    }
                }

                maxSaturationDegreeNode = maxSaturationDegreeNode ?? currentNodes.First();
                nodeColorProvider.ProvideNodeColor(graph, maxSaturationDegreeNode, colorOrder);
                coloredNodes.Add(maxSaturationDegreeNode);
                currentNodes.Remove(maxSaturationDegreeNode);
            }
        }

        private int CalculateSaturationDegree(Node node, Graph graph, HashSet<Node> coloredNodes)
        {
            IEnumerable<Node> coloredNeighbours = graph.GetNodeNeighbours(node).ToHashSet().Intersect(coloredNodes);
            return coloredNeighbours.Select(neighbour => neighbour.Color).ToHashSet().Count;
        }
    }
}
