using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using System.Diagnostics;

namespace CSE.API
{
    class GoogleAPI
    {

        public static void ImageToText(string filePath)
        {
           /* Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                @"C:\Users\Michal\Downloads\ComparisonShoppingEngine-7f01b74f865a.json"
            );*/

            var client = ImageAnnotatorClient.Create();
            var image = Image.FromFile(filePath);
            var response = client.DetectText(image);
            Debug.WriteLine("HELLO");
        }
    }
}