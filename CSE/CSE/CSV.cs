using CSE.FrontEnd;
using CSE.BackEnd;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSE
{
    class CSV
    {    
        string pathRegistration = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "registration.csv");
        private string _fileOfUniqueProducts = "unique_products.csv";

        public void WriteToFileProducts(List<Product> list, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in list)
            {
                sb.Append(value.ToString());
            }
            File.WriteAllText(filePath, sb.ToString());
        }
        public void ResetUniqueProducts()
        {
            FormsToolkit formsToolKit = new FormsToolkit();
            var paths = formsToolKit.Ddaf.GetFilesPaths();
            var uniqueProducts = ParsingUniqueProducts(paths);
            if (!(File.Exists(_fileOfUniqueProducts)))
            {
                StreamWriter writer = File.CreateText(_fileOfUniqueProducts);
            }
            else
            {
                StreamWriter writer = File.AppendText(_fileOfUniqueProducts);
                var csv = new CsvWriter(writer);
                 foreach (var item in uniqueProducts)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item.Name);
                    sb.Append(",0");
                    writer.WriteLine(sb);
                }
                writer.Close();
            }
        }
        public void UpdatePopularity(List<KeyValuePair<string, int>> products)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in products)
                {
                    sb.Append(item.Key);
                    sb.Append(",");
                    sb.Append(item.Value);
                    sb.Append("\n");
                }
                File.WriteAllText(_fileOfUniqueProducts, sb.ToString());

            }
            catch (Exception) { }
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
        public List<string> ParsingUniqueProducts()
        {
            List<string> result = new List<string>();
            if(File.Exists(_fileOfUniqueProducts))
            {
                StreamReader reader = File.OpenText(_fileOfUniqueProducts);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if (row == null)
                    {
                        reader.Close();
                        break;
                    }
                    if (!result.Exists(x => x == row[0]))
                    {
                        result.Add(row[0]);
                    }
                }
            }
            return result;
        }
        
        public List<KeyValuePair<string,int>> GetAllProductsByPopularity()
        {
            var temporaryDictionary = new Dictionary<string, int>();
            try
            {
                StreamReader reader = File.OpenText(_fileOfUniqueProducts);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if (row == null)
                    {
                        reader.Close();
                        break;
                    }
                    if (!temporaryDictionary.ContainsKey(row[0]))
                    {
                        temporaryDictionary.Add(row[0], Int32.Parse(row[1]));
                    }
                }
                var result = (
                                   from entry in temporaryDictionary
                                   orderby entry.Value
                                   descending
                                   select entry
                               );
                return result.ToList();
            }
            catch (FormatException) { return null; }
            //catch (ArgumentNullException) { return null; }
            catch (OverflowException) { return null; }
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
        public List<Product> ParsingProductsOfStore(string file)
        {
            List<Product> result = new List<Product>();
            StreamReader reader = File.OpenText(file);
            var parser = new CsvParser(reader);
            while (true)
            {
                var row = parser.Read();
                if (row == null)
                {
                    reader.Close();
                    break;
                }
                result.Add(new Product(row[0],Decimal.Parse(row[1])));
            }
            return result;
        }

        public List<string> ParsingOneFileNames(string path)
        {
            var list = new List<string>();

            if (File.Exists(pathRegistration))
            {
                StreamReader reader = File.OpenText(path);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if (row == null)
                    {
                        reader.Close();
                        break;
                    }
                    list.Add(row[0]);
                }
            }

            return list;
        }

        public List<ProductDetails> ParsingDetailsFile(string path, string name)
        {
            var list = new List<ProductDetails>();
            if (File.Exists(path))
            {
                StreamReader reader = File.OpenText(path);
                var parser = new CsvParser(reader);
                while (true)
                {
                    var row = parser.Read();
                    if (row == null)
                    {
                        reader.Close();
                        break;
                    }
                    list.Add(new ProductDetails(row[0], Decimal.Parse(row[1]), DateTime.ParseExact(row[2], "yyyy-MM-dd", CultureInfo.InvariantCulture), Int32.Parse(row[3])));
                }
            }
            return list;
        }
    }
}
