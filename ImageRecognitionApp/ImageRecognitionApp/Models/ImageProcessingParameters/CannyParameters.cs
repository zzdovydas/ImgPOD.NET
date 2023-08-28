using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class CannyParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "CannyAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new CannyParametersTemplate();
        public int Threshold1 { get; set; }
        public int Threshold2 { get; set; }
        public int ApertureSize { get; set; }
        public bool L2Gradient { get; set; }

    }
}
