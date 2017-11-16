using System.Drawing;
using System.Threading.Tasks;
using Logic.ImageAnalysis.OCR;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Logic.ImageAnalysis
{
    public class ImageProcessing 
    {
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                //set graphics settings
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public bool SuitableSize(Image image)
        {
            return (image.HorizontalResolution >= 300 && image.VerticalResolution >=300) ? true : false;
        }

        public Bitmap RescaleImage(Bitmap image)
        {
            var verticalResolutionScale = 300 / image.VerticalResolution;
            var horizontalResolutionScale = 300 / image.HorizontalResolution;

            var desiredWidth = (int)(image.Width * horizontalResolutionScale)+1;
            var desiredHeight = (int)(image.Height * verticalResolutionScale)+1;

            var newImage = ResizeImage(image, desiredWidth, desiredHeight);
            return newImage;
        }

        public Bitmap ImproveImageQuality(Bitmap image)
        {
            return SuitableSize(image) ? image : RescaleImage(image);
        }
        ///Improve the quality of the image.
        ///Process the image.
        
        public async Task<string> GetTextFromImage(Bitmap image)
        {
            var ocr = new TesseractOCR();
            var improvedImage = ImproveImageQuality(image);
            var result = await ocr.GetText(improvedImage);
            return result;
        }
    }
}
