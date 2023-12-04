namespace CommonProject
{
    public class Graph
    {
        private readonly int size;
        private Dictionary<Node, HashSet<Node>> adjacencyList;
        private List<Node> vertices;

        public Graph(int size)
        {
            this.size = size;
            this.InitializeDefaultVerticesAndEdges();
        }

        #region Properties

        public int Size
        {
            get { return size; }
        }

        public List<Node> Nodes
        {
            get { return vertices; }
        }

        public Dictionary<Node, HashSet<Node>> AdjacencyList
        {
            get { return this.adjacencyList; }
        }

        #endregion

        public bool AddEdge(Node x, Node y)
        {
            if (!this.adjacencyList.ContainsKey(x) || !this.adjacencyList.ContainsKey(y))
                return false;

            this.adjacencyList[x].Add(y);
            this.adjacencyList[y].Add(x);

            return true;
        }

        private void InitializeDefaultVerticesAndEdges()
        {
            this.vertices = new List<Node>(this.size);
            this.adjacencyList = new Dictionary<Node, HashSet<Node>>(this.size);

            for (int i = 0; i < this.size; i++)
            {
                var newNode = new Node(i);
                this.adjacencyList.Add(newNode, new HashSet<Node>());
                this.vertices.Add(newNode);
            }
        }
    }
}
