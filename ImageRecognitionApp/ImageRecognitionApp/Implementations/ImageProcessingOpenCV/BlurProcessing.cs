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
    internal class BlurProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName =>  "BlurAlgorithm"; 
            
        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            BlurParameters p = parameters.BlurParameters;
            Mat result = src.GaussianBlur(new OpenCvSharp.Size(p.KSize, p.KSize), p.Sigma);
            sourceImg.Image = result.ToBytes();

            return sourceImg;
        }
    }
}
