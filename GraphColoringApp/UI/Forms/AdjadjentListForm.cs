using CommonProject;
using System.Text;

namespace UI.Forms
{
    internal partial class AdjadjentListForm : Form
    {
        internal AdjadjentListForm(Graph graph)
        {
            this.InitializeComponent();
            this.InitializeListBox(graph);
        }

        private void InitializeListBox(Graph graph)
        {
            var sb = new StringBuilder();
            foreach (Node u in graph.Nodes)
            {
                sb.Clear();
                sb.Append(u.SerialNumber);
                sb.Append("-> [ ");
                foreach (Node v in graph.AdjacencyList[u])
                {
                    sb.Append(v.SerialNumber);
                    sb.Append("  ");
                }
                sb.Append($"] Node color: [{u.Color.A}, {u.Color.R}, {u.Color.G}, {u.Color.B}]");
                this.lbAdjList.Items.Add(sb.ToString());
            }
        }
    }
}
