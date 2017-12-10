using System.Collections.Generic;
using LogicLibrary.Models;

namespace LogicLibrary.DataManagement
{
    public interface IConverter
    {
        Receipt ConvertImageToReceipt(byte[] imageArgs);
        IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts);
        int SaveReceipt(byte[] image);
    }
}