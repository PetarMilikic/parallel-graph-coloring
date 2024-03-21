using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProviders
{
    internal sealed class IDOGraphColoringProvider : IGraphSequentialColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            var colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);
            var nodeColorProvider = new FirstFitNodeColorProvider();
            HashSet<Node> currentNodes = graph.Nodes.ToHashSet();
            var coloredNodes = new HashSet<Node>();
            Node maxIncidencyDegreeNode;
            int maxIncidencyDegree = -1;

            while (currentNodes.Count > 0)
            {
                maxIncidencyDegreeNode = null;
                maxIncidencyDegree = -1;

                foreach (Node node in currentNodes)
                {
                    int incidencyDegree = this.CalculateIncidencyDegree(node, graph, coloredNodes);
                    if (incidencyDegree > maxIncidencyDegree)
                    {
                        maxIncidencyDegreeNode = node;
                        maxIncidencyDegree = incidencyDegree;
                    }
                }

                maxIncidencyDegreeNode = maxIncidencyDegreeNode ?? currentNodes.First();
                nodeColorProvider.ProvideNodeColor(graph, maxIncidencyDegreeNode, colorOrder);
                coloredNodes.Add(maxIncidencyDegreeNode);
                currentNodes.Remove(maxIncidencyDegreeNode);
            }
        }

        private int CalculateIncidencyDegree(Node node, Graph graph, HashSet<Node> coloredNodes)
        {
            return coloredNodes.Intersect(graph.GetNodeNeighbours(node)).Count();
        }
    }
}
