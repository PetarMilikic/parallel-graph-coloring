using UIGraphModel = Microsoft.Msagl.Drawing.Graph;
using Graph = CommonProject.Graph;
using UI.Forms;
using System.Diagnostics;
using CommonProject.Interfaces;
using CommonProject;
using UI.Utilities;
using ColorProviders.Interfaces;
using ColorProviders.Factories;

namespace UI
{
    internal partial class MainForm : Form
    {
        private Graph graph;
        private DateTime lastGeneratedGraphTime;
        private DateTime lastColoringTime;
        private TimeSpan lastColoringTimeSpan;
        private TimeSpan lastGenerationGraphTimeSpan;
        private List<string> algorithmInfoList;

        internal MainForm()
        {
            this.InitializeComponent();
            this.algorithmInfoList = new List<string>();
            this.graph = new Graph(0);
            this.lastColoringTimeSpan = TimeSpan.Zero;
            this.lastColoringTime = DateTime.MinValue;
            this.PopulateChooseAlgorithmComboBox();
        }

        private void GenerateRandomGraph(int graphSize)
        {
            var factory = new RandomGraphProviderFactory();
            IRandomGraphProvider randomGraphProvider = factory.Create();
            this.graph = randomGraphProvider.Get(graphSize);
        }

        private void RefreshInfoLabel()
        {
            string message = $"Random Graph with {this.graph.Size} nodes last generated on {this.lastGeneratedGraphTime}, Used time: {this.lastGenerationGraphTimeSpan}";

            if (this.lastColoringTime != DateTime.MinValue)
                message += $", Coloring generated on: {this.lastColoringTime} with {((AlgorithmNode)this.cmbChooseAlgorithm.SelectedItem).Name} algorithm, Used time: {this.lastColoringTimeSpan}, Used colors: {this.graph.Nodes.Select(node => node.Color).ToHashSet().Count}";

            this.lblGraphInfo.Text = message;
        }

        private void PopulateChooseAlgorithmComboBox()
        {
            var algorithmNodes = new List<AlgorithmNode>();
            foreach (AlgorithmType algorithmType in Enum.GetValues(typeof(AlgorithmType)))
            {
                var algorithmNode = new AlgorithmNode(algorithmType);
                algorithmNodes.Add(algorithmNode);
            }

            this.cmbChooseAlgorithm.DataSource = algorithmNodes;
            this.cmbChooseAlgorithm.DisplayMember = "Name";
        }

        private void btnStartColoring_Click(object sender, EventArgs e)
        {
            this.graph.ResetNodeColors();

            AlgorithmType algorithmType = ((AlgorithmNode)this.cmbChooseAlgorithm.SelectedItem).AlgoritimType;
            var graphColoringProviderFactory = new GraphColoringProviderFactory();
            IGraphColoringProvider coloringProvider = graphColoringProviderFactory.Create(algorithmType);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            coloringProvider.ProvideNodeColors(this.graph);
            stopwatch.Stop();

            this.lastColoringTime = DateTime.Now;
            this.lastColoringTimeSpan = stopwatch.Elapsed;

            this.algorithmInfoList.Add($"Coloring generated on: { this.lastColoringTime} with { ((AlgorithmNode)this.cmbChooseAlgorithm.SelectedItem).Name} algorithm, Used time: { this.lastColoringTimeSpan.TotalSeconds} , Used colors: { this.graph.Nodes.Select(node => node.Color).ToHashSet().Count}");

            this.RefreshInfoLabel();
        }

        private void btnVisualizeRezults_Click(object sender, EventArgs e)
        {
            var uiGraphModelProvider = new UIGraphModelProvider();
            UIGraphModel graphModel = uiGraphModelProvider.Get(this.graph);
            this.graphViewer.Graph = graphModel;
            this.graphViewer.Refresh();
        }

        private void btnGenerateRandomGraph_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtRandomGraphSize.Text, out int randomGraphSize))
            {
                MessageBox.Show("Invalid graph size format.\nPlease insert valid graph size.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.algorithmInfoList.Clear();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            this.GenerateRandomGraph(randomGraphSize);
            stopwatch.Stop();

            this.lastGenerationGraphTimeSpan = stopwatch.Elapsed;
            this.lastGeneratedGraphTime = DateTime.Now;
            this.lastColoringTimeSpan = TimeSpan.Zero;
            this.lastColoringTime = DateTime.MinValue;
            this.RefreshInfoLabel();
        }

        private void btnDisplayAdjList_Click(object sender, EventArgs e)
        {
            using (var form = new AdjadjentListForm(this.graph))
            {
                form.ShowDialog();
            }
        }

        private void btnCheckColoring_Click(object sender, EventArgs e)
        {
            int conflicts = this.CalculateNumberOfColoringConflicts();

            if (conflicts == 0)
                MessageBox.Show("Coloring ended with no conflicts.", "Corectness Check Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Coloring ended with {conflicts} conflicts.", "Corectness Check Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private int CalculateNumberOfColoringConflicts()
        {
            int numberOfConflicts = 0;

            foreach (var node in this.graph.Nodes)
                foreach (var neighbour in this.graph.AdjacencyList[node])
                    if (node.Color == neighbour.Color)
                        numberOfConflicts++;

            return numberOfConflicts;
        }

        private void btnShowComparisonResult_Click(object sender, EventArgs e)
        {
            string graphGenerationInfo = $"Random Graph with {this.graph.Size} last generated on {this.lastGeneratedGraphTime}, Used time: {this.lastGenerationGraphTimeSpan}";

            using(var comparisonForm = new AlgorithmComparisonForm(graphGenerationInfo, this.algorithmInfoList))
            {
                comparisonForm.ShowDialog();
            }
        }
    }
}