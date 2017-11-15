using System.Drawing;
using System.Threading.Tasks;
using Tesseract;

namespace Logic.ImageAnalysis.OCR
{
    class TesseractOCR : IOCR
    {
        public Task<string> ImageToText(Bitmap image)
        {
            var ocr = new TesseractEngine("./tessdata", "eng");
            var page = ocr.Process(image);
            ocr.SetVariable("tessedit_pageseg_mode", 6);
            return Task.Run(() =>
            {
                return page.GetText().Replace("\n", "\r\n");
            });
        }
    }
}
