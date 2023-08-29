using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Interfaces.ImageProcessing;
using ImageRecognitionApp.Models;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Implementations.ImageProcessing
{
    internal class DilateProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName => "DilateAlgorithm";

        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            DilateParameters p = parameters.DilateParameters;
            Mat element = new Mat();

            if (p.Element?.Image != null)
            {
                element = Cv2.ImDecode(p.Element.Image, ImreadModes.Color);
            }

            Point? anchor = null;

            if (p.AnchorX != null && p.AnchorY != null)
            {
                anchor = new Point((int)p.AnchorX, (int)p.AnchorY);
            }

            Mat result = src.Dilate(element, anchor, p.Iterations);
            sourceImg.Image = result.ToBytes();

            return sourceImg;
        }
    }
}
