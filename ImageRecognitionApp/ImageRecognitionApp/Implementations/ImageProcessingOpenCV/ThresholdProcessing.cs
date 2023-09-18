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
    internal class ThresholdProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName => "ThresholdAlgorithm"; 
            
        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            ThresholdParameters p = parameters.ThresholdParameters;
            Mat result = src.Threshold(p.Threshold, p.MaxValue, (OpenCvSharp.ThresholdTypes)p.Type);
            sourceImg.Image = result.ToBytes();

            return sourceImg;
        }
    }
}
