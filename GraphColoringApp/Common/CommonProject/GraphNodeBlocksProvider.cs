using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject
{
    public class GraphNodeBlocksProvider
    {
        public ConcurrentDictionary<int, ConcurrentBag<Node>> GetBlocksByIndex(Graph graph, int numberOfBlocks)
        {
            var blocks = new ConcurrentDictionary<int, ConcurrentBag<Node>>(Environment.ProcessorCount, numberOfBlocks);
            
            Parallel.For(0, numberOfBlocks, index =>
            {
                blocks[index] = new ConcurrentBag<Node>();
            });

            Parallel.ForEach(graph.Nodes, node =>
            {
                blocks[node.SerialNumber % numberOfBlocks].Add(node);

            });

            return blocks;

        }

        public ConcurrentDictionary<int, ConcurrentBag<Node>> GetBlocksByIndex(List<Node> nodeGroup, int numberOfBlocks)
        {
            var blocks = new ConcurrentDictionary<int, ConcurrentBag<Node>>(Environment.ProcessorCount, numberOfBlocks);

            Parallel.For(0, numberOfBlocks, index =>
            {
                blocks[index] = new ConcurrentBag<Node>();
            });

            Parallel.ForEach(nodeGroup, node =>
            {
                blocks[node.SerialNumber % numberOfBlocks].Add(node);
            });

            return blocks;

        }
    }
}
