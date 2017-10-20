using System.Drawing;
using Tesseract;
namespace CSE
{
    class TesseractOCR :IOCR
    {
        /// <summary>
        /// Standard English characters are recognised.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ImageToText(string fileName)
        {
            var img = new Bitmap(fileName);
            var ocr = new TesseractEngine("./tessdata", "eng");
               var page = ocr.Process(img);
             ocr.SetVariable("tessedit_pageseg_mode", 6);
            return page.GetText().Replace("\n","\r\n");
        }
    }
}