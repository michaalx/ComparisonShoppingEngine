using System.Drawing;

namespace LogicCore.ImageAnalysis.OCR
{
    interface IOCR
    {
        string ImageToText(Bitmap image);
    }
}
