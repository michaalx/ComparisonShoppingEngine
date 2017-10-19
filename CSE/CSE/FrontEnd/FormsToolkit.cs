using CSE.BackEnd;
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
        public List<Product> ListOfItems { get; set; }

        public DataDistributionAmongFiles Ddaf { get; set; }
        public CheapestStore TheCheapestStore { get; set; }
        public TextProcessor ClosestMatch { get; set; }
        public string File { get; set; }
        public FormsToolkit()
        {
            this.ListOfItems = new List<Product>();
            this.Ddaf = new DataDistributionAmongFiles();
            this.TheCheapestStore = new CheapestStore();
        }
        public static void DisplayMessageBox(string message, string caption = "Errod detected in input.")
        {
            MessageBoxButtons messageBox = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, messageBox);
            return;
        }
        public static void DisplayPopularProducts()
        {
            CSV csvTool = new CSV();
            DataToolkit dataToolkit = new DataToolkit();
            StringBuilder stringBuilder = new StringBuilder();
            string caption = "The most popular products.";
            List<KeyValuePair<string,int>> popoularProducts = dataToolkit?.GetPopularProducts(5);
            if(popoularProducts!=null)
            foreach(var item  in popoularProducts)
            {
                stringBuilder.Append(item.Key);
                stringBuilder.Append("\n");
            }
            DisplayMessageBox(stringBuilder.ToString(), caption);
        }
        public void DisplayCheapestStoreInfo(string storeName, decimal sum)
        {
            var message = "The cheapest store to do the shopping is " + storeName;
            message +="\n The estimated sum is "+sum.ToString();
            MessageBox.Show(message);
        }
        
    }
}
