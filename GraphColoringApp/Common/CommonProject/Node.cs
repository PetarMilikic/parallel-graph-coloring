using System.Drawing;

namespace CommonProject
{
    public class Node
    {
        private readonly int serialNumber;
        private Color color;
        private int priority;

        public Node(int serialNumber, Color? color = null)
        {
            this.serialNumber = serialNumber;
            this.color = color ?? Color.Empty;
        }

        #region Properties

        public int SerialNumber
        {
            get { return this.serialNumber; }
        }

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public int Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }

        #endregion
    }
}
