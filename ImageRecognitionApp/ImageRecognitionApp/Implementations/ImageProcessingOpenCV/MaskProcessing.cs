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
    internal class MaskProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName => "MaskAlgorithm";

        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            MaskParameters p = parameters.MaskParameters;
            Mat mask = new Mat();

            if (p.Mask?.Image != null)
            {
                mask = Cv2.ImDecode(p.Mask.Image, ImreadModes.Color);
            }

            Mat result = src.Subtract(mask);
            sourceImg.Image = result.ToBytes();

            return sourceImg;
        }
    }
}
