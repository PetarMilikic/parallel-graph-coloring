using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorProviders.Utiliies
{
    internal class RandomColorProvider
    {
        private readonly Random randomizer;

        internal RandomColorProvider()
        {
            this.randomizer = new Random();
        }

        internal Color ProvideRandomColor()
        {
            return Color.FromArgb(randomizer.Next(100, 255), randomizer.Next(255), randomizer.Next(255), randomizer.Next(255));
        }

        internal List<Color> ProvideRandomColorList(int size)
        {
            HashSet<Color> colorSet = this.ProvideRandomColorSet(size);
            return colorSet.ToList();
        }

        internal HashSet<Color> ProvideRandomColorSet(int size)
        {
            var colorSet = new HashSet<Color>(size);

            for (int i = 0; i < size; i++)
                colorSet.Add(this.ProvideRandomColor());

            while (colorSet.Count != size)
                colorSet.Add(this.ProvideRandomColor());

            return colorSet;
        }
    }
}
