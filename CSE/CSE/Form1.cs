using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSE.BackEnd;
namespace CSE
{
    public partial class Form1 : Form
    {
        List<Product> listOfItems = new List<Product>();
        DataDistributionAmongFiles ddaf = new DataDistributionAmongFiles();
        CheapestStore choose = new CheapestStore();
        //ListViewOperations lwo = new ListViewOperations();
        private TextProcessor ClosestMatch { get; set; }
		public string file { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
		private void Form1_Closing(object sender, FormClosingEventArgs e)
		{
			System.Environment.Exit(1);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    string fullPath = Path.GetFullPath(file);
                    pathBox.Text = fullPath;
                    ifError.Text = "";
                }
                catch (IOException)
                {
                }
                catch(ArgumentNullException)
                {
                }
            } else if (openFileDialog1.FileName == "")
            {
                ifError.Text = "File not chosen";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
			try
            {
                var shop = (Store)Enum.Parse(typeof(Store), comboBox.Text);
                var textProcessor = new TextProcessor(TesseractOCR.ImageToText(file).Split('\n'));
				textProcessor.CleanEmptyLines();
			//	textProcessor.CleanIrrelevantLines();
				textProcessor.SeparateNamePrice();
				textProcessor.FindMatch();
                //This has to be in other class
                var products = textProcessor.GetProductList().Select(x => x.ToString()).ToArray();
                var prices = textProcessor.GetPriceList().Select(x => x.ToString()).ToArray();
                //
                ddaf.ToProductList(products,prices);
              //  ddaf.StoreDataToFile(shop);
                panel2.Visible = true;
                panel1.SendToBack();
            }
            catch (IOException)
            {
            }
            catch(ArgumentNullException)
            {
            }
            catch(ArgumentException)
            {
                ifError.Text = "Invalid file format";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel2.SendToBack();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
            ListInit();
            ListViewItems_Init();
        }
        //Adding items to listView
        public void ListViewItems_Init()
        {
            foreach (var item in listOfItems)
            {
                listViewItems.Items.Add(item.Name);
            }
        }

        //Parsing products from files
        private void ListInit()
        {
            CSV csv = new CSV();
            string[] paths = ddaf.GetFilesPaths();
            listOfItems = csv.ParsingUniqueProducts(paths);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_Resize(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

        private void insertReceiptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            panel1.BringToFront();
            panel3.SendToBack();
        }

        private void chooseItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel3.BringToFront();
            panel1.SendToBack();
        }

        //adds selected products from one list to other(cart)
        private void addButton_Click(object sender, EventArgs e)
        {
           //lwo.CopySelectedItems(listViewItems,listViewCart);
        }

        private void CheapestStoreButton_Click(object sender, EventArgs e)
        {
            var result = choose.GetCheapestStore(listViewCart);
            cheapestStore.Text = "You should go to " + result.ToUpper();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
          //  lwo.RemoveSelectedItems(listViewCart);
            cheapestStore.Text = "";
        }
    }
}
