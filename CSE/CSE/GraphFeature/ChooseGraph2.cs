using CSE.BackEnd;
using CSE.FrontEnd;
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
    public partial class ChooseGraph2 : Form
    {
        string PathForStore;
        Store SavedStore;
        GraphOperations graph = new GraphOperations();
        CSV csvTool = new CSV();
        public ChooseGraph2(string path,Store store)
        {
            InitializeComponent();
            PathForStore = path;
            SavedStore = store;
        }

        private void ChooseGraph2_Load(object sender, EventArgs e)
        {
            ListViewInit();
        }

        private void ListViewInit()
        {
            var preList = csvTool.ParsingOneFileNames(PathForStore);
            foreach (var item in preList)
            {
                listViewGraph.Items.Add(item);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                string item = listViewGraph.SelectedItems[0].Text;
                PathForStore = graph.GetPath(SavedStore, PathForStore);
                var list = graph.GetListDays(PathForStore,item);
                var graphForm = new Graph(list,item);
                graphForm.Show();
                this.Hide();
            //}
            /*catch (Exception)
            {
                notSelected.Text = "Select an item";
            }*/
            
        }
    }
}
