namespace UI.Forms
{
    partial class AdjadjentListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            lbAdjList = new ListBox();
            tlpMain.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMain.Controls.Add(lbAdjList, 0, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.Size = new Size(1056, 523);
            tlpMain.TabIndex = 0;
            // 
            // lbAdjList
            // 
            lbAdjList.Dock = DockStyle.Fill;
            lbAdjList.FormattingEnabled = true;
            lbAdjList.ItemHeight = 20;
            lbAdjList.Location = new Point(3, 3);
            lbAdjList.Name = "lbAdjList";
            lbAdjList.Size = new Size(1050, 517);
            lbAdjList.TabIndex = 0;
            // 
            // AdjadjentListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 523);
            Controls.Add(tlpMain);
            Name = "AdjadjentListForm";
            Text = "Adjadjent List Form";
            tlpMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private ListBox lbAdjList;
    }
}