using CSE.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.GraphFeature
{
    public partial class ChooseGraph : Form
    {
        CSV csvtool = new CSV();
        GraphOperations graph = new GraphOperations();
        public ChooseGraph()
        {
            InitializeComponent();
        }

        private void ChooseGraph_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            var chosen = (Store)Enum.Parse(typeof(Store), comboBoxStore.Text);
            var pathForStore = graph.GetPath(chosen);
            var newGraph = new ChooseGraph2(pathForStore,chosen);
            newGraph.Show();
            this.Hide();
        }
    }
}
