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
    // https://github.com/shimat/opencvsharp/issues/173
    internal class CannyProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName =>  "CannyAlgorithm"; 
            
        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            CannyParameters p = parameters.CannyParameters;
            Mat result = src.Canny(p.Threshold1, p.Threshold2, p.ApertureSize, p.L2Gradient);
            sourceImg.Image = result.ToBytes();

            return sourceImg;
        }
    }
}
