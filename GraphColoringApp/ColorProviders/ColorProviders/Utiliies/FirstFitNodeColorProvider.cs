using CommonProject;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProviders.Utiliies
{
    internal class FirstFitNodeColorProvider
    {
        private readonly object lockObject = new object();

        internal void ProvideNodeColor(Graph graph, Node node, List<Color> colorOrder)
        {
            HashSet<Color> colorMask = graph.GetNeighbourColorsForNode(node);
            foreach (Color color in colorOrder)
                if (!colorMask.Contains(color))
                {
                    lock (lockObject)
                    {
                        node.Color = color;
                    }

                    return;
                }
        }
    }
}
