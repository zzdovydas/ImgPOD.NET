using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class BlurParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "BlurAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new BlurParametersTemplate();
        public int KSize { get; set; }
        public int Sigma { get; set; }

    }
}
