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
    internal sealed class AdvancedBlockPartitioningColorProvider : IGraphParallelColoringProvider
    {
        public void ProvideNodeColors(Graph graph)
        {
            //Phase 1:
            int numberOfBlocks = Environment.ProcessorCount;
            var blocksProvider = new GraphNodeBlocksProvider();
            ConcurrentDictionary<int, ConcurrentBag<Node>> blocks = blocksProvider.GetBlocksByIndex(graph, numberOfBlocks);
            List<Color> colorOrder = new RandomColorProvider().ProvideRandomColorList(graph.Size);

            Parallel.ForEach(blocks, block =>
            {
                var subgraphColoringProvider = new FirstFitGraphColoringProvider(block.Value.ToList(), colorOrder);
                subgraphColoringProvider.ProvideNodeColors(graph);
            });

            List<List<Node>> nodeGroups = this.GetNodeGroupsByColor(graph, colorOrder); //TODO: Try with reversed collection
            int numberOfGroups = nodeGroups.Count;
            graph.ResetNodeColors();

            //Phase 2:
            foreach (List<Node> nodeGroup in nodeGroups)
            {
                List<ConcurrentBag<Node>> groupBlocks = blocksProvider.GetBlocksByIndex(nodeGroup, numberOfBlocks).Values.ToList();

                Parallel.ForEach(groupBlocks, block =>
                {
                    var subgraphColoringProvider = new FirstFitGraphColoringProvider(block.ToList(), colorOrder);
                    subgraphColoringProvider.ProvideNodeColors(graph);
                });
            }

            ConcurrentBag<Node> nodesToRecolor = this.GetConflictedNodes(graph, blocks);
            this.ResetNodeColors(nodesToRecolor);
            var restColorNodesProvider = new FirstFitModifiedGraphColoringProvider(colorOrder,nodesToRecolor.ToList());
            restColorNodesProvider.ProvideNodeColors(graph);
        }

        private ConcurrentBag<Node> GetConflictedNodes(Graph graph, ConcurrentDictionary<int, ConcurrentBag<Node>> nodeBlocksByIndex)
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

        private List<List<Node>> GetNodeGroupsByColor(Graph graph, List<Color> colorOrder)
        {
            List<IGrouping<Color, Node>> groups = graph.Nodes.GroupBy(node => node.Color).ToList();
            Dictionary<Color, int> indexByColor = colorOrder.ToDictionary(kvp => kvp, kvp => colorOrder.IndexOf(kvp));

            groups.Sort((x, y) =>
            {
                if (indexByColor[x.Key] < indexByColor[y.Key])
                    return 1;
                return -1;
            });

            return groups.Select(group => group.ToList()).ToList();
        }

        public void ResetNodeColors(ConcurrentBag<Node> nodes)
        {
            Parallel.ForEach(nodes, node =>
            {
                node.Color = Color.Empty;
            });
        }
    }
}
