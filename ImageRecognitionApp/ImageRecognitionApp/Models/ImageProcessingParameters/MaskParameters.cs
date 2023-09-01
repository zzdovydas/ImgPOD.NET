using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class MaskParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "MaskAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new MaskParametersTemplate();
        public IImage Mask { get; set; }
    }
}
