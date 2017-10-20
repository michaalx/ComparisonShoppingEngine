using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSE;

namespace UnitTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductListTest()
        {
            DataDistributionAmongFiles ddaf = new DataDistributionAmongFiles();
            string[] products = new string[] { "product1", "product2" };
            string[] prices = new string[] { "10,99", "1,80" };
            ddaf.ToProductList(products, prices);
            List<Product> productList = new List<Product>();
            productList = ddaf.GetProductsList();

            string expected = "product1 10,99";
            string actual = productList[0].Name + " " + productList[0].Price.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
