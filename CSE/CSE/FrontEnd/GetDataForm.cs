using CSE.BackEnd;
using CSE.GraphFeature;
using System;
using System.Windows.Forms;

namespace CSE.FrontEnd
{
    public partial class GetDataForm : Form
    {
        private PopularProductsForm _popularProductsForm;
        public GetDataForm()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            Hide();
            StartForm startForm = new StartForm();
            startForm.Show();
        }

        private void CompareProductPrices_Click(object sender, EventArgs e)
        {
            Hide();
            CompareProductPricesForm compareProductPricesForm = new CompareProductPricesForm();
            compareProductPricesForm.Show();
        }

        private void GetDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void PopularButton_OnClick(object sender, EventArgs e)
        {
            DataToolkit dataToolkit = new DataToolkit();
                _popularProductsForm = new PopularProductsForm(dataToolkit.PreparePopularProducts());
                _popularProductsForm.Show();
        }

        private void StatisticsButton_OnClick(object sender, EventArgs e)
        {
            ChooseGraph initialGraph = new ChooseGraph();
            initialGraph.Show();
        }
    }
}
