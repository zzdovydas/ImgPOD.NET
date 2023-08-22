using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Utils.ImageProcessing
{
    internal static class ImageProcessingHelpers
    {
        public static Bitmap ByteArrayToBitmap(byte[] imgBytes)
        {
            Bitmap result;
            using (var ms = new MemoryStream(imgBytes))
            {
                result = new Bitmap(ms);
            }
            return result;
        }
    }
}
