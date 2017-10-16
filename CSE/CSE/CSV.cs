using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE
{
    class CSV
    {    
        string pathRegistration = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "registration.csv");
        public void WriteToFileProducts(List<Product> list, string filePath)
        {
            if (!(File.Exists(filePath)))
            {
                StreamWriter writer = File.CreateText(filePath);
            } else
            {
                StreamWriter writer = File.AppendText(filePath);
                var csv = new CsvWriter(writer);
                foreach (var value in list)
                {
                    csv.WriteRecord(value);
                    csv.NextRecord();
                }
                writer.Close();
            }
        }
        /// <summary>
        /// Modified method.
        /// Only one user is able to sign up during session.
        /// </summary>
        /// <param name="user"></param>
        public void WriteToFileRegistration(User user)
        {
            if (!(File.Exists(pathRegistration)))
            {
                StreamWriter writer = File.CreateText(pathRegistration);
            }
            else
            {
                StreamWriter writer = File.AppendText(pathRegistration);
                var csv = new CsvWriter(writer);
               // foreach (var value in list)
                //{
                    csv.WriteRecord(user);
                //}
                writer.Close();
            }
        }
        public bool ParsingRegistration(string email)
        {
            if(File.Exists(pathRegistration)) 
            {
                StreamReader reader = File.OpenText(pathRegistration);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if( row == null )
                    {
                        reader.Close();
                        break;
                    }
                    if (row[2] == email)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ParsingRegistration(string email, string password)
        {
           if(File.Exists(pathRegistration))
            {
                StreamReader reader = File.OpenText(pathRegistration);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if (row == null)
                    {
                        reader.Close();
                        break;
                    }
                    if (row[2] == email && row[3] == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //parsing for listView
        public List<Product> ParsingUniqueProducts(string[] filePaths)
        {
            List<Product> list = new List<Product>();
            foreach (var filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    StreamReader reader = File.OpenText(filePath);
                    var parser = new CsvParser(reader);
                    while (true)
                    {
                        var row = parser.Read();
                        if (row == null)
                        {
                            reader.Close();
                            break;
                        }
                        var prod = new Product(row[0], Decimal.Parse(row[1]));
                        if (!list.Exists(x => x.Name == prod.Name))
                            list.Add(prod);
                    }
                }
            }
            return list;
        }

        public List<Product> ParsingForChosenItems(ListView cart, string file)
        {
            List<string> cartList = cart.Items.Cast<ListViewItem>()
                             .Select(item => item.Text)
                             .ToList();
            List<Product> originProducts = new List<Product>();
            List<Product> matchingProducts = new List<Product>();
            StreamReader reader = File.OpenText(file);
            var parser = new CsvParser(reader);
            //parsing from file (all items)
            while (true)
            {
                var row = parser.Read();
                if (row == null)
                {
                    reader.Close();
                    break;
                }
                originProducts.Add(new Product(row[0], Decimal.Parse(row[1])));
            }
            //querying for matching item
            foreach(var item in cartList)
            {
                var queryMatchingItem = from product in originProducts
                                    where product.Name == item
                                    select product;
                foreach(var productn in queryMatchingItem)
                {
                    matchingProducts.Add(productn);
                }
            }
            return matchingProducts;
        }
    }
}
