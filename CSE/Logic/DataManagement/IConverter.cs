using System.Collections.Generic;
using Logic.Models;

namespace Logic.DataManagement
{
    public interface IConverter
    {
        Receipt ConvertImageToReceipt(string imageArgs);
        IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts);
    }
}