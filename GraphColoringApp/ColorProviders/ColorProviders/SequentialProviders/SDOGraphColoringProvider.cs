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
            Node maxIncidencyDegreeNode;
            int maxSaturationDegree = -1;

            while (currentNodes.Count > 0)
            {
                maxIncidencyDegreeNode = null;
                maxSaturationDegree = -1;

                foreach (Node node in currentNodes)
                {
                    int saturationDegree = this.CalculateSaturationDegree(node, graph, coloredNodes);
                    if (saturationDegree > maxSaturationDegree)
                    {
                        maxIncidencyDegreeNode = node;
                        maxSaturationDegree = saturationDegree;
                    }
                }

                maxIncidencyDegreeNode = maxIncidencyDegreeNode ?? currentNodes.First();
                nodeColorProvider.ProvideNodeColor(graph, maxIncidencyDegreeNode, colorOrder);
                coloredNodes.Add(maxIncidencyDegreeNode);
                currentNodes.Remove(maxIncidencyDegreeNode);
            }
        }

        private int CalculateSaturationDegree(Node node, Graph graph, HashSet<Node> coloredNodes)
        {
            var coloredNeighbours = graph.AdjacencyList[node].ToHashSet().Intersect(coloredNodes);
            return coloredNeighbours.Select(v => v.Color).ToHashSet().Count;
        }
    }
}
