using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CSE.FrontEnd
{
    class FormsToolkit
    {
        public static void DisplayInputError(string message)
        {
            var caption = "Error detected in input.";
            MessageBoxButtons messageBox = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, messageBox);
            return;
        }
        /// <summary>
        ///Method that takes all products that are available in at least two stores. 
        /// </summary>
        public static void AddItemsToComparePricesList(CompareProductPricesForm form)
        {
            /*
             For a while, I will use only array of products that is already made
             Later I will make a method that makes a list of products 
             from selected products that are available in at least two stores.
             */
             
        }
        public static void InitializeProductDatabase()
        {

        }
    }
}
