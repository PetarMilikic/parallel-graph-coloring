using CommonProject.Interfaces;

namespace CommonProject
{
    internal class RandomGraphProvider : IRandomGraphProvider
    {
        private readonly ParallelOptions parallelOptions;

        internal RandomGraphProvider()
        {
            this.parallelOptions = new ParallelOptions();
        }

        public Graph Get(int size)
        {
            var graph = new Graph(size);

            Parallel.ForEach(graph.Nodes, this.parallelOptions,  u =>
                {
                    Random randomizer = new Random();
                    foreach (Node v in graph.Nodes)
                        if (u != v && Math.Abs(randomizer.Next()) % 5 == 0)
                            graph.AddEdge(u, v);
                });

            return graph;
        }
    }
}
