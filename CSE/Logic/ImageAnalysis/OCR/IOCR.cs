using System.Drawing;
using System.Threading.Tasks;

namespace Logic.ImageAnalysis
{
    interface IOCR
    {
        string ImageToText(Bitmap image);
    }
}
