using System.Collections.Concurrent;
using System.Drawing;

namespace CommonProject
{
    public class Graph
    {
        private readonly object lockObject = new object();
        private ConcurrentDictionary<Node, HashSet<Node>> adjacencyList;
        private ConcurrentBag<Node> vertices;

        public Graph(int size)
        {
            this.InitializeDefaultVerticesAndEdges(size);
        }

        private Graph(ConcurrentDictionary<Node, HashSet<Node>> adjacencyList)
        {
            this.vertices = new ConcurrentBag<Node>(adjacencyList.Keys);
            this.adjacencyList = adjacencyList;
        }

        #region Properties

        public int Size
        {
            get { return this.adjacencyList.Count; }
        }

        public ConcurrentBag<Node> Nodes
        {
            get { return new ConcurrentBag<Node>(this.adjacencyList.Keys); }
        }

        public ConcurrentDictionary<Node, HashSet<Node>> AdjacencyList
        {
            get { return this.adjacencyList; }
        }

        public HashSet<Color> NodeColors
        {
            get { return this.Nodes.Select(node => node.Color).ToHashSet(); }
        }

        #endregion

        public IEnumerable<Node> GetNodeNeighbours(Node node)
        {
            return this.adjacencyList[node];
        }

        public Graph GetCopy()
        {
            var newAdjacencyList = new ConcurrentDictionary<Node, HashSet<Node>>(this.adjacencyList.ToDictionary(kvp => kvp.Key, kvp => new HashSet<Node>(kvp.Value)));
            return new Graph(newAdjacencyList);
        }

        public int GetNodeDegree(Node node)
        {
            return this.adjacencyList[node].Count;
        }

        public HashSet<Color> GetNeighbourColorsForNode(Node node)
        {
            return this.adjacencyList[node].Select(neighbour => neighbour.Color).Where(color => color != Color.Empty).ToHashSet();
        }

        public void ResetNodeColors() //TODO: Remove this
        {
            Parallel.ForEach(this.vertices,
                node => node.Color = Color.Empty);
        }

        public Graph GetInducedSubgraph(HashSet<Node> nodeSet)
        {
            IEnumerable<KeyValuePair<Node, HashSet<Node>>> adjacencyList = this.adjacencyList.Where(kvp => nodeSet.Contains(kvp.Key));

            var newAdjacencyList = new ConcurrentDictionary<Node, HashSet<Node>>(adjacencyList.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Intersect(nodeSet).ToHashSet()));
            return new Graph(newAdjacencyList);
        }

        public bool AddEdge(Node x, Node y)
        {
            if (!this.adjacencyList.ContainsKey(x) || !this.adjacencyList.ContainsKey(y))
                return false;

            lock (lockObject)
            {
                this.adjacencyList[x].Add(y);
                this.adjacencyList[y].Add(x);
            }

            return true;
        }

        private void InitializeDefaultVerticesAndEdges(int size)
        {
            this.vertices = new ConcurrentBag<Node>();
            this.adjacencyList = new ConcurrentDictionary<Node, HashSet<Node>>(Environment.ProcessorCount * 2, size);

            for (int i = 0; i < size; i++)
            {
                var newNode = new Node(i);
                this.adjacencyList.TryAdd(newNode, new HashSet<Node>());
                this.vertices.Add(newNode);
            }
        }
    }
}
