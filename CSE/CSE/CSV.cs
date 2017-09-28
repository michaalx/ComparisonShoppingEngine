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
        public void writeToFile(List<Product> list)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\giedr\Desktop\cse\records.csv");
            var csv = new CsvWriter(writer);
            foreach (var value in list)
            {
                csv.WriteRecord(value);
            }
            writer.Close();
        }   
    }
}
