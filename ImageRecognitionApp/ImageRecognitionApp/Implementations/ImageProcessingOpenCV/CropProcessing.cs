using ImageRecognitionApp.Extensions;
using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Interfaces.ImageProcessing;
using ImageRecognitionApp.Models;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using ImageRecognitionApp.Utils.ImageProcessing;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Implementations.ImageProcessing
{
    internal class CropProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName =>  "CropAlgorithm"; 
            
        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            IImage result = new ImageImpl();

            CropParameters p = parameters.CropParameters;
            Bitmap b = ImageProcessingHelpers.ByteArrayToBitmap(sourceImg.Image);

            Bitmap b1 = b.Crop(new Rectangle() { X = p.X, Y = p.Y, Width = p.Width, Height = p.Height });
            result.Image = b1.ToBytes(ImageFormat.Png);

            return result;
        }
    }
}
