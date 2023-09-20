using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class ContourParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "ContoursAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new ContourParametersTemplate();
    }
}
