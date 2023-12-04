namespace UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tlpMain = new TableLayoutPanel();
            graphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            tlpControllOptions = new TableLayoutPanel();
            flpControlsLeft = new FlowLayoutPanel();
            lblGraphSize = new Label();
            txtRandomGraphSize = new TextBox();
            lblChooseColoringAlgorithm = new Label();
            cmbChooseAlgorithm = new ComboBox();
            tlpControlsLeft = new TableLayoutPanel();
            btnGenerateRandomGraph = new Button();
            btnStartColoring = new Button();
            btnVisualizeRezults = new Button();
            btnDisplayAdjList = new Button();
            pbLogo = new PictureBox();
            flpDownPanel = new FlowLayoutPanel();
            lblGraphInfo = new Label();
            tlpMain.SuspendLayout();
            tlpControllOptions.SuspendLayout();
            flpControlsLeft.SuspendLayout();
            tlpControlsLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            flpDownPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(graphViewer, 1, 1);
            tlpMain.Controls.Add(tlpControllOptions, 1, 0);
            tlpMain.Controls.Add(tlpControlsLeft, 0, 1);
            tlpMain.Controls.Add(pbLogo, 0, 0);
            tlpMain.Controls.Add(flpDownPanel, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpMain.Size = new Size(1091, 517);
            tlpMain.TabIndex = 0;
            // 
            // graphViewer
            // 
            graphViewer.ArrowheadLength = 10D;
            graphViewer.AsyncLayout = false;
            graphViewer.AutoScroll = true;
            graphViewer.BackwardEnabled = false;
            graphViewer.BuildHitTree = true;
            graphViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            graphViewer.Dock = DockStyle.Fill;
            graphViewer.EdgeInsertButtonVisible = true;
            graphViewer.FileName = "";
            graphViewer.ForwardEnabled = false;
            graphViewer.Graph = null;
            graphViewer.IncrementalDraggingModeAlways = false;
            graphViewer.InsertingEdge = false;
            graphViewer.LayoutAlgorithmSettingsButtonVisible = true;
            graphViewer.LayoutEditingEnabled = true;
            graphViewer.Location = new Point(303, 43);
            graphViewer.LooseOffsetForRouting = 0.25D;
            graphViewer.MouseHitDistance = 0.05D;
            graphViewer.Name = "graphViewer";
            graphViewer.NavigationVisible = true;
            graphViewer.NeedToCalculateLayout = true;
            graphViewer.OffsetForRelaxingInRouting = 0.6D;
            graphViewer.PaddingForEdgeRouting = 8D;
            graphViewer.PanButtonPressed = false;
            graphViewer.SaveAsImageEnabled = true;
            graphViewer.SaveAsMsaglEnabled = true;
            graphViewer.SaveButtonVisible = true;
            graphViewer.SaveGraphButtonVisible = true;
            graphViewer.SaveInVectorFormatEnabled = true;
            graphViewer.Size = new Size(785, 431);
            graphViewer.TabIndex = 0;
            graphViewer.TightOffsetForRouting = 0.125D;
            graphViewer.ToolBarIsVisible = true;
            graphViewer.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("graphViewer.Transform");
            graphViewer.UndoRedoButtonsVisible = true;
            graphViewer.WindowZoomButtonPressed = false;
            graphViewer.ZoomF = 1D;
            graphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // tlpControllOptions
            // 
            tlpControllOptions.ColumnCount = 1;
            tlpControllOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpControllOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpControllOptions.Controls.Add(flpControlsLeft, 0, 0);
            tlpControllOptions.Dock = DockStyle.Fill;
            tlpControllOptions.Location = new Point(303, 3);
            tlpControllOptions.Name = "tlpControllOptions";
            tlpControllOptions.RowCount = 1;
            tlpControllOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpControllOptions.Size = new Size(785, 34);
            tlpControllOptions.TabIndex = 1;
            // 
            // flpControlsLeft
            // 
            flpControlsLeft.AutoSize = true;
            flpControlsLeft.BackColor = SystemColors.ScrollBar;
            flpControlsLeft.Controls.Add(lblGraphSize);
            flpControlsLeft.Controls.Add(txtRandomGraphSize);
            flpControlsLeft.Controls.Add(lblChooseColoringAlgorithm);
            flpControlsLeft.Controls.Add(cmbChooseAlgorithm);
            flpControlsLeft.Dock = DockStyle.Fill;
            flpControlsLeft.Location = new Point(3, 3);
            flpControlsLeft.Name = "flpControlsLeft";
            flpControlsLeft.Size = new Size(779, 34);
            flpControlsLeft.TabIndex = 0;
            // 
            // lblGraphSize
            // 
            lblGraphSize.Anchor = AnchorStyles.Left;
            lblGraphSize.AutoSize = true;
            lblGraphSize.Location = new Point(3, 7);
            lblGraphSize.Name = "lblGraphSize";
            lblGraphSize.Size = new Size(143, 20);
            lblGraphSize.TabIndex = 0;
            lblGraphSize.Text = "Random Graph Size:";
            // 
            // txtRandomGraphSize
            // 
            txtRandomGraphSize.Anchor = AnchorStyles.Left;
            txtRandomGraphSize.Location = new Point(152, 3);
            txtRandomGraphSize.Name = "txtRandomGraphSize";
            txtRandomGraphSize.Size = new Size(125, 27);
            txtRandomGraphSize.TabIndex = 1;
            // 
            // lblChooseColoringAlgorithm
            // 
            lblChooseColoringAlgorithm.Anchor = AnchorStyles.Left;
            lblChooseColoringAlgorithm.AutoSize = true;
            lblChooseColoringAlgorithm.Location = new Point(283, 7);
            lblChooseColoringAlgorithm.Name = "lblChooseColoringAlgorithm";
            lblChooseColoringAlgorithm.Size = new Size(193, 20);
            lblChooseColoringAlgorithm.TabIndex = 2;
            lblChooseColoringAlgorithm.Text = "Choose Coloring Algorithm:";
            // 
            // cmbChooseAlgorithm
            // 
            cmbChooseAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChooseAlgorithm.FormattingEnabled = true;
            cmbChooseAlgorithm.Location = new Point(482, 3);
            cmbChooseAlgorithm.Name = "cmbChooseAlgorithm";
            cmbChooseAlgorithm.Size = new Size(264, 28);
            cmbChooseAlgorithm.TabIndex = 4;
            // 
            // tlpControlsLeft
            // 
            tlpControlsLeft.BackColor = SystemColors.ControlDark;
            tlpControlsLeft.ColumnCount = 1;
            tlpControlsLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpControlsLeft.Controls.Add(btnGenerateRandomGraph, 0, 0);
            tlpControlsLeft.Controls.Add(btnStartColoring, 0, 1);
            tlpControlsLeft.Controls.Add(btnVisualizeRezults, 0, 2);
            tlpControlsLeft.Controls.Add(btnDisplayAdjList, 0, 3);
            tlpControlsLeft.Dock = DockStyle.Fill;
            tlpControlsLeft.Location = new Point(3, 43);
            tlpControlsLeft.Name = "tlpControlsLeft";
            tlpControlsLeft.RowCount = 5;
            tlpControlsLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpControlsLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpControlsLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpControlsLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpControlsLeft.RowStyles.Add(new RowStyle());
            tlpControlsLeft.Size = new Size(294, 431);
            tlpControlsLeft.TabIndex = 2;
            // 
            // btnGenerateRandomGraph
            // 
            btnGenerateRandomGraph.Dock = DockStyle.Fill;
            btnGenerateRandomGraph.Location = new Point(3, 3);
            btnGenerateRandomGraph.Name = "btnGenerateRandomGraph";
            btnGenerateRandomGraph.Size = new Size(288, 34);
            btnGenerateRandomGraph.TabIndex = 1;
            btnGenerateRandomGraph.Text = "Generate Random Graph";
            btnGenerateRandomGraph.UseVisualStyleBackColor = true;
            btnGenerateRandomGraph.Click += btnGenerateRandomGraph_Click;
            // 
            // btnStartColoring
            // 
            btnStartColoring.Dock = DockStyle.Fill;
            btnStartColoring.Location = new Point(3, 43);
            btnStartColoring.Name = "btnStartColoring";
            btnStartColoring.Size = new Size(288, 34);
            btnStartColoring.TabIndex = 0;
            btnStartColoring.Text = "Process Coloring";
            btnStartColoring.UseVisualStyleBackColor = true;
            btnStartColoring.Click += btnStartColoring_Click;
            // 
            // btnVisualizeRezults
            // 
            btnVisualizeRezults.Dock = DockStyle.Fill;
            btnVisualizeRezults.Location = new Point(3, 83);
            btnVisualizeRezults.Name = "btnVisualizeRezults";
            btnVisualizeRezults.Size = new Size(288, 34);
            btnVisualizeRezults.TabIndex = 2;
            btnVisualizeRezults.Text = "Visualize Results";
            btnVisualizeRezults.UseVisualStyleBackColor = true;
            btnVisualizeRezults.Click += btnVisualizeRezults_Click;
            // 
            // btnDisplayAdjList
            // 
            btnDisplayAdjList.Dock = DockStyle.Fill;
            btnDisplayAdjList.Location = new Point(3, 123);
            btnDisplayAdjList.Name = "btnDisplayAdjList";
            btnDisplayAdjList.Size = new Size(288, 34);
            btnDisplayAdjList.TabIndex = 3;
            btnDisplayAdjList.Text = "Display Adjadjency List";
            btnDisplayAdjList.UseVisualStyleBackColor = true;
            btnDisplayAdjList.Click += btnDisplayAdjList_Click;
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Fill;
            pbLogo.Location = new Point(3, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(294, 34);
            pbLogo.TabIndex = 3;
            pbLogo.TabStop = false;
            // 
            // flpDownPanel
            // 
            flpDownPanel.BackColor = SystemColors.ScrollBar;
            tlpMain.SetColumnSpan(flpDownPanel, 2);
            flpDownPanel.Controls.Add(lblGraphInfo);
            flpDownPanel.Dock = DockStyle.Fill;
            flpDownPanel.Location = new Point(3, 480);
            flpDownPanel.Name = "flpDownPanel";
            flpDownPanel.Size = new Size(1085, 34);
            flpDownPanel.TabIndex = 4;
            // 
            // lblGraphInfo
            // 
            lblGraphInfo.Anchor = AnchorStyles.Left;
            lblGraphInfo.AutoSize = true;
            lblGraphInfo.Location = new Point(3, 0);
            lblGraphInfo.Name = "lblGraphInfo";
            lblGraphInfo.Size = new Size(0, 20);
            lblGraphInfo.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 517);
            Controls.Add(tlpMain);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Graph Coloring Manager";
            tlpMain.ResumeLayout(false);
            tlpControllOptions.ResumeLayout(false);
            tlpControllOptions.PerformLayout();
            flpControlsLeft.ResumeLayout(false);
            flpControlsLeft.PerformLayout();
            tlpControlsLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            flpDownPanel.ResumeLayout(false);
            flpDownPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Microsoft.Msagl.GraphViewerGdi.GViewer graphViewer;
        private TableLayoutPanel tlpControllOptions;
        private FlowLayoutPanel flpControlsLeft;
        private Label lblGraphSize;
        private TextBox txtRandomGraphSize;
        private Label lblChooseColoringAlgorithm;
        private Button btnStartColoring;
        private ComboBox cmbChooseAlgorithm;
        private TableLayoutPanel tlpControlsLeft;
        private Button btnGenerateRandomGraph;
        private Button btnVisualizeRezults;
        private PictureBox pbLogo;
        private FlowLayoutPanel flpDownPanel;
        private Label lblGraphInfo;
        private Button btnDisplayAdjList;
    }
}