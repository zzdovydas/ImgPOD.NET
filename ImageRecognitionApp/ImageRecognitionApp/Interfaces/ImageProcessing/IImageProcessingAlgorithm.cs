using ImageRecognitionApp.Models;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Interfaces.ImageProcessing
{
    internal interface IImageProcessingAlgorithm
    {
        string AlgorithmName { get; }
        IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters);
    }
}
