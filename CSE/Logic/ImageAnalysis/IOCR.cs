using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ImageAnalysis
{
    interface IOCR
    {
        Task<string> ImageToText(Bitmap image);
    }
}
