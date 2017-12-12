using LogicCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicCore.DataManagement
{
    public interface IConverter
    {
        Receipt ConvertImageToReceipt(byte[] imageArgs);
        IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts);
        int SaveReceipt(byte[] image);
    }
}
