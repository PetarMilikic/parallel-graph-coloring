namespace UI.Forms
{
    partial class AlgorithmComparisonForm
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
            lbColoringInfo = new ListBox();
            SuspendLayout();
            // 
            // lbColoringInfo
            // 
            lbColoringInfo.Dock = DockStyle.Fill;
            lbColoringInfo.FormattingEnabled = true;
            lbColoringInfo.ItemHeight = 20;
            lbColoringInfo.Location = new Point(0, 0);
            lbColoringInfo.Name = "lbColoringInfo";
            lbColoringInfo.Size = new Size(1239, 473);
            lbColoringInfo.TabIndex = 0;
            // 
            // AlgorithmComparisonForm
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 473);
            Controls.Add(lbColoringInfo);
            Name = "AlgorithmComparisonForm";
            ShowIcon = false;
            Text = "Comparison Form";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbColoringInfo;
    }
}