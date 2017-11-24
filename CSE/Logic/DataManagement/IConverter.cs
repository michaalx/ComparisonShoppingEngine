using System.Collections.Generic;
using Logic.Models;

namespace Logic.DataManagement
{
    public interface IConverter
    {
        Receipt ConvertImageToReceipt(byte[] imageArgs);
        IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts);
        int SaveReceipt(byte[] image);
    }
}