using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.FrontEnd
{
    public partial class CompareProductPricesForm : Form
    {
        public List<string> ListOfSelectedItems { get; set; }
        /// <summary>
        /// Additional form in order to seperate front-end
        /// from back-end.
        /// </summary>
        public FormsToolkit formsToolKit = new FormsToolkit();
        public CompareProductPricesForm()
        {
            ListOfSelectedItems = new List<string>();   
            InitializeComponent();
        }
        /// <summary>
        /// Method that returns union of products
        /// from all stores.
        /// Alternative to be considered:
        /// products that belong to all stores.
        /// </summary>
        /// <returns></returns>
        private List<Product> GetListOfItems()
        {
            CSV csv = new CSV();
            var allPaths = formsToolKit.Ddaf.GetFilesPaths();
            return csv.ParsingUniqueProducts(allPaths);
        }
        /// <summary>
        /// Add all products to display form (listView)
        /// </summary>
        private void AddItemsToListView()
        {
            var listOfItems = GetListOfItems();
            foreach(var item in listOfItems)
            {
                listViewOfAllProducts.Items.Add(item.Name);
            }
        }
        /// <summary>
        /// Overloaded method.
        /// Called when items are deleted in Cart Form.
        /// </summary>
        /// <param name="items"></param>
        public void AddItemsToListView(List<string> items)
        {
            foreach(var item in items)
            {
                AddItemToListView(item);
            }
        }
        public void AddItemToListView(string item)
        {
            listViewOfAllProducts.Items.Add(item);
        }
        private void CompareProductPricesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void CompareProductPricesForm_Load(object sender, EventArgs e)
        {
            AddItemsToListView();
        }

        private void AddToCartButton_OnClick(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listViewOfAllProducts.CheckedItems)
            {
                ListOfSelectedItems.Add(item.Text);
                listViewOfAllProducts.Items.Remove(item);
            }
        }
        /// <summary>
        /// Method needed in order to avoid products duplication
        /// when removing from cart and opening cart again.
        /// </summary>
        /// <param name="item"></param>
        public void UnselectItem(string item)
        {
            ListOfSelectedItems.Remove(item);
        }
        private void ShowCartButton_OnClick(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(ListOfSelectedItems,this);
            cartForm.Show();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            GetDataForm getDataForm = new GetDataForm();
            getDataForm.Show();
        }
    }
}
