using CSE.BackEnd;
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
    public partial class PopularProductsForm : Form
    {
        public List<Tuple<string, string, decimal>> PopularProductDetails { get; }
        public PopularProductsForm(List<Tuple<string, string, decimal>> popularProducts)
        {
            InitializeComponent();
            PopularProductDetails = popularProducts;
            foreach(var item in popularProducts)
            {
                string price = item.Item3.ToString();
                string[] attributes = { item.Item1, item.Item2, price };
                ListViewItem listViewItem = new ListViewItem(attributes);
                listViewOfPopularProducts.Items.Add(listViewItem);
            }
        }

        private void listViewOfAllProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GoBackButton_OnClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void PopularProductsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void PopularProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            var listOfSelectedItems = listViewOfPopularProducts.CheckedItems;
            var listOfSelectedItemsString = new List<string>();
            for(int index=0;index<listOfSelectedItems.Count;index++)
            {
                listOfSelectedItemsString.Add(listOfSelectedItems[index].Text);
                Debug.WriteLine(listOfSelectedItems[index].Text);
            }
            CompareProductPricesForm compareProductPricesForm = new CompareProductPricesForm
            {
                ListOfSelectedItems = listOfSelectedItemsString
            };
            Hide();
            compareProductPricesForm.Show();
            compareProductPricesForm.ShowCartButton_OnClick(sender, e);
        }
    }
}
