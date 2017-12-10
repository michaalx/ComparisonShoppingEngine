using System.Drawing;
using System.Threading.Tasks;

namespace LogicLibrary.ImageAnalysis
{
    interface IOCR
    {
        string ImageToText(Bitmap image);
    }
}
