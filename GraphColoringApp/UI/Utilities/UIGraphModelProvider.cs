using Microsoft.Msagl.Drawing;
using UIGraphModel = Microsoft.Msagl.Drawing.Graph;
using Graph = CommonProject.Graph;
using Node = CommonProject.Node;
using UINode = Microsoft.Msagl.Drawing.Node;

namespace UI.Utilities
{
    internal class UIGraphModelProvider
    {
        internal UIGraphModel Get(Graph graph)
        {
            var graphModel = new UIGraphModel("Random Graph");
            graphModel.Directed = false;

            foreach (Node node in graph.Nodes)
            {
                var uiNode = new UINode(node.SerialNumber.ToString());
                uiNode.Attr.Shape = Shape.Circle;
                uiNode.Attr.FillColor = new Microsoft.Msagl.Drawing.Color(node.Color.A, node.Color.R, node.Color.G, node.Color.B);
                graphModel.AddNode(uiNode);
            }

            var addedEdges = new Dictionary<int, HashSet<int>>();
            foreach (Node node in graph.Nodes)
                addedEdges[node.SerialNumber] = new HashSet<int>();

            foreach (Node u in graph.Nodes)
            {
                foreach (Node v in graph.AdjacencyList[u])
                {
                    if (addedEdges[u.SerialNumber].Contains(v.SerialNumber) || addedEdges[v.SerialNumber].Contains(u.SerialNumber))
                        continue;

                    addedEdges[u.SerialNumber].Add(v.SerialNumber);
                    Edge edge = graphModel.AddEdge(u.SerialNumber.ToString(), v.SerialNumber.ToString());
                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Gray;
                    edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                }
            }

            return graphModel;

        }
    }
}
