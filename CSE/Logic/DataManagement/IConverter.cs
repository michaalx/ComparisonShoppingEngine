using System.Collections.Generic;
using System.Drawing;
using Logic.Models;

namespace Logic.DataManagement
{
    public interface IConverter
    {
        IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts);
        Receipt ConvertImageToReceipt(string image);
    }
}