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
       // string pathRecord = @"C:\Users\giedr\Desktop\cse\records.csv";
        string pathRegistration = @"C:\Users\giedr\Desktop\cse\registration.csv";
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
        public void WriteToFileRegistration(List<User> list)
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
            //if (File.Exists(pathRecord))
            //Maybe you have mentioned this?
            if(File.Exists(pathRegistration)) 
            //-----------------------------------
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
           // if (File.Exists(pathRecord))
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
    }
}
