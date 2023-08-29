using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class DilateParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "DilateAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new DilateParametersTemplate();
        public IImage Element { get; set; }
        public int? AnchorX { get; set; }
        public int? AnchorY { get; set; }
        public int Iterations { get; set; }

    }
}
