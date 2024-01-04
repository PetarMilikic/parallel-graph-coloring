using ColorProviders.Interfaces;
using ColorProviders.Utiliies;
using CommonProject;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProviders
{
    internal sealed class GMGraphColoringProvider : IGraphParallelColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            ConcurrentBag<Node> currentNodes = graph.Nodes;
            List<Color> coloringOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);
            var nodeColorProvider = new FirstFitNodeColorProvider();

            while (currentNodes.Count > 0)
            {
                Parallel.ForEach(currentNodes, node =>
                {
                    nodeColorProvider.ProvideNodeColor(graph, node, coloringOrder);
                });

                var nodesToRecolor = new ConcurrentBag<Node>();

                Parallel.ForEach(currentNodes, node =>
                {
                    foreach (Node neighbour in graph.AdjacencyList[node])
                        if (node.Color == neighbour.Color && node.SerialNumber < neighbour.SerialNumber)
                        {
                            nodesToRecolor.Add(node);
                            break;
                        }
                });

                currentNodes = nodesToRecolor;
            }
        }
    }
}
