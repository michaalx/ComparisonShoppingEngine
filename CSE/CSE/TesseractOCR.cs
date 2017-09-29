using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
namespace CSE
{
    class TesseractOCR
    {
        /// <summary>
        /// The initial version of Tesseract-OCR image
        /// processing method.
        /// Standard English characters are recognised.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ImageToText(string fileName)
        {
            //Image<Bgr, Byte> image = emgu.ToImage<Bgr, Byte>();
            var img = new Bitmap(fileName);
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            var page = ocr.Process(img);
            return page.GetText().Replace("\n","\r\n");
        }
    }
}
