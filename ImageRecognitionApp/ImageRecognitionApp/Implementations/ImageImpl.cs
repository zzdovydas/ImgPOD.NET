using ImageRecognitionApp.Interfaces;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Implementations
{

    // Current image implementation for working with OpenCVSharp
    internal class ImageImpl : IImage
    {
        private Mat OpenCvImage { get; set; }
        public byte[] Image {
            get { return OpenCvImage.ToBytes(); }
            set { OpenCvImage = Cv2.ImDecode(value, ImreadModes.Color); }
        }

        public IImage ImageFromFile(string fileName )
        {
            OpenCvImage = new Mat(fileName);
            return this;
        }

        object ICloneable.Clone()
        {
            var newImage = new ImageImpl();
            newImage.Image = Image;
            return newImage;
        }
    }
}
