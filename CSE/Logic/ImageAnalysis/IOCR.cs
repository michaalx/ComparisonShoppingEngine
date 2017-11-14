using System.Drawing;
using System.Threading.Tasks;

namespace Logic.ImageAnalysis
{
    interface IOCR
    {
        Task<string> ImageToText(Bitmap image);
    }
}
