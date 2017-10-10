using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.FrontEnd
{
    public partial class CompareProductPricesForm : Form
    {
        public CompareProductPricesForm()
        {
            InitializeComponent();
          //  FormsToolkit.AddItemsToComparePricesList(this);
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            GetDataForm getDataForm = new GetDataForm();
            getDataForm.Show(); 
        }
    }
}
