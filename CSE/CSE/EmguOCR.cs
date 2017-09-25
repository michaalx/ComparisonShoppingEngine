using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class EmguOCR
    {
        public static Mat ImageToCanny(string fileName)
        {
            Mat imgOriginal = new Mat(fileName, ImreadModes.Color);

            Mat imgGrayscale = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgBlurred = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);
            Mat imgCanny = new Mat(imgOriginal.Size, DepthType.Cv8U, 1);

            CvInvoke.CvtColor(imgOriginal, imgGrayscale, ColorConversion.Bgr2Gray);
            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(5, 5), 1.5);
            CvInvoke.Canny(imgBlurred, imgCanny, 100, 200);

            return imgCanny;
        }
    }
}
