using CommonProject;

namespace ColorProviders.Utiliies
{
    internal class MaximalIndependentSetProvider
    {
        internal HashSet<Node> Get(Graph graph)
        {
            var result = new HashSet<Node>();
            HashSet<Node> currentNodes = graph.Nodes.ToHashSet();

            while (currentNodes.Count > 0)
            {
                int maxDegree = currentNodes.Max(node => graph.GetNodeDegree(node));
                Node maxDegreeNode = currentNodes.First(v => graph.GetNodeDegree(v) == maxDegree);
                result.Add(maxDegreeNode);

                HashSet<Node> nodesToExclude = graph.AdjacencyList[maxDegreeNode].ToHashSet();
                nodesToExclude.Add(maxDegreeNode);

                currentNodes.ExceptWith(nodesToExclude);
            }

            return result;
        }
    }
}
