using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class CSV
    {    
        string pathRecord = @"C:\Users\giedr\Desktop\cse\records.csv";
        string pathRegistration = @"C:\Users\giedr\Desktop\cse\registration.csv";
        public void writeToFileProducts(List<Product> list)
        {
            if (!(File.Exists(pathRecord)))
            {
                StreamWriter writer = File.CreateText(pathRecord);
            } else
            {
                StreamWriter writer = File.AppendText(pathRecord);
                var csv = new CsvWriter(writer);
                foreach (var value in list)
                {
                    csv.WriteRecord(value);
                    csv.NextRecord();
                }
                writer.Close();
            }
        }
        public void writeToFileRegistration(List<User> list)
        {
            if (!(File.Exists(pathRegistration)))
            {
                StreamWriter writer = File.CreateText(pathRegistration);
            } else
            {
                StreamWriter writer = File.AppendText(pathRegistration);
                var csv = new CsvWriter(writer);
                foreach (var value in list)
                {
                    csv.WriteRecord(value);
                }
                writer.Close();
            }
        }
        public bool ParsingRegistration(string email)
        {
            if (File.Exists(pathRecord))
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
            if (File.Exists(pathRecord))
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
    }
}
