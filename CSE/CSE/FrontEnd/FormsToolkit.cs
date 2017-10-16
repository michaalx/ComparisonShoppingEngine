using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CSE.FrontEnd
{
    public class FormsToolkit
    {
        public List<Product> ListOfItems { get; set; }// = new List<Product>();

        public DataDistributionAmongFiles Ddaf { get; set; }// = new DataDistributionAmongFiles();
        public CheapestStore TheCheapestStore { get; set; }// = new CheapestStore();
        public ListViewOperations TheListViewOperations { get; set; }// = new ListViewOperations();
        public TextProcessor ClosestMatch { get; set; }
        public string File { get; set; }
        public FormsToolkit()
        {
            this.ListOfItems = new List<Product>();
            this.Ddaf = new DataDistributionAmongFiles();
            this.TheCheapestStore = new CheapestStore();
            this.TheListViewOperations = new ListViewOperations();
        }
        public static void DisplayInputError(string message)
        {
            var caption = "Error detected in input.";
            MessageBoxButtons messageBox = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, messageBox);
            return;
        }
        public void DisplayCheapestStoreInfo(string storeName, decimal sum)
        {
            var message = "The cheapest store to do the shopping is " + storeName;
            message +="\n The estimated sum is "+sum.ToString();
            MessageBoxButtons messageBox = MessageBoxButtons.OK;
            MessageBox.Show(message);
        }
        /// <summary>
        ///Method that takes all products that are available in at least two stores. 
        /// </summary>
        public void AddItemsToComparePricesList()
        {
           
        }
    
        public static void InitializeProductDatabase()
        {

        }
    }
}
