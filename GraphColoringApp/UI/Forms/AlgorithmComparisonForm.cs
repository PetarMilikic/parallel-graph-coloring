using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class AlgorithmComparisonForm : Form
    {
        private const string itemSeparator = "--------------------------------------------------------------------------------------------------------------";
        private const string duplicatedItemSeparator = itemSeparator + itemSeparator;

        public AlgorithmComparisonForm(string randomGraphGenerationInfo, List<string> algorithmInfoList)
        {
            InitializeComponent();
            this.lbColoringInfo.Items.Add(randomGraphGenerationInfo);
            this.lbColoringInfo.Items.Add(duplicatedItemSeparator);

            foreach (string algorithmInfo in algorithmInfoList)
            {
                this.lbColoringInfo.Items.Add(algorithmInfo);
                this.lbColoringInfo.Items.Add(itemSeparator);
            }
        }
    }
}
