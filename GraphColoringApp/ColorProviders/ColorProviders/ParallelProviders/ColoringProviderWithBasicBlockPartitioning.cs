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
    internal sealed class ColoringProviderWithBasicBlockPartitioning : IGraphParallelColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            //Phase 1:
            int numberOfBlocks = Environment.ProcessorCount;
            var blocksProvider = new GraphNodeBlocksProvider();
            var nodeBlocks = blocksProvider.GetBlocksByIndex(graph, numberOfBlocks);
            List<Color> colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);
            var nodeColorProvider = new FirstFitNodeColorProvider();

            Parallel.ForEach(nodeBlocks, block =>
            {
                var firstFitColoringProvider = new FirstFitGraphColoringProvider(block.Value.ToList(), colorOrder);
                firstFitColoringProvider.ProvideNodeColors(graph);
            });

            //Phase 2:
            ConcurrentBag<Node> nodesToRecolor = this.GetCollisionNodes(graph, nodeBlocks);
            this.ResetNodeColors(nodesToRecolor);
            var colorProviderForNodesInCollision = new FirstFitModifiedGraphColoringProvider(colorOrder, nodesToRecolor.ToList());
            colorProviderForNodesInCollision.ProvideNodeColors(graph);
        }

        private ConcurrentBag<Node> GetCollisionNodes(Graph graph, ConcurrentDictionary<int, ConcurrentBag<Node>> nodeBlocksByIndex)
        {
            ConcurrentBag<Node> nodesToRecolor = new ConcurrentBag<Node>(); //TODO: Try with HashSet with synchronization
            Parallel.ForEach(nodeBlocksByIndex, block =>
            {
                foreach (Node node in block.Value)
                    foreach (Node neighbour in graph.AdjacencyList[node])
                        if (node.Color == neighbour.Color && node.SerialNumber < neighbour.SerialNumber)
                            nodesToRecolor.Add(node);
            });

            return nodesToRecolor;
        }

        private void ResetNodeColors(ConcurrentBag<Node> nodes)
        {
            Parallel.ForEach(nodes, node =>
            {
                node.Color = Color.Empty;
            });
        }
    }
}
