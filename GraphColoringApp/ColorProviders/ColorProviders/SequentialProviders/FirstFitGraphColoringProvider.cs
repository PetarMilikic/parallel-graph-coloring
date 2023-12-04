using ColorProviders.Interfaces;
using CommonProject;
using System.Drawing;

namespace ColorProviders
{
    public class FirstFitGraphColoringProvider : IGraphSequentialColoringProvider
    {   
        public void ProvideNodeColors(Graph graph)
        {
            var colorOrder = new List<Color>();
            var randomizer = new Random();

            foreach (Node node in graph.Nodes)
            {
                HashSet<Color> colorMask = graph.AdjacencyList[node].Select(neighbour => neighbour.Color).Where(color => color != Color.Empty).ToHashSet();
                bool colorFounded = false;

                foreach (Color color in colorOrder)
                    if (!colorMask.Contains(color))
                    {
                        node.Color = color;
                        colorFounded = true;
                        break;
                    }

                if (!colorFounded)
                {
                    Color newColor = Color.FromArgb(randomizer.Next(100, 255), randomizer.Next(255), randomizer.Next(255), randomizer.Next(255));
                    node.Color = newColor;
                    colorOrder.Add(newColor);
                };
            }
        }
    }
}
