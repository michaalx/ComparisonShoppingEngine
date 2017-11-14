using System.Drawing;
using System.Threading.Tasks;
using Tesseract;

namespace Logic.ImageAnalysis
{
    public class ImageProcessing : IOCR
    {
        public Task<string> ImageToText(Bitmap image)
        {
            /*
             *var ocr = new AutoOcr();
              var result = ocr.Read(image);
              return Task.Run(() =>
                  {
                      return result.Text;
                   });
                   */
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
