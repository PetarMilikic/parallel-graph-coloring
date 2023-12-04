using CommonProject.Interfaces;

namespace CommonProject
{
    internal class RandomGraphProvider : IRandomGraphProvider
    {
        public Graph Get(int size)
        {
            var graph = new Graph(size);
            var randomizer = new Random();

            foreach (Node u in graph.Nodes)
                foreach (Node v in graph.Nodes)
                    if (u != v && Math.Abs(randomizer.Next()) % 2 == 0)
                        graph.AddEdge(u, v);

            return graph;
        }
    }
}
