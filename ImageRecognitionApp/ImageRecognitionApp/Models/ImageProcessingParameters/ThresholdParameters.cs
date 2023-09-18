using ImageRecognitionApp.Implementations.AlgorithmParameterTemplates;
using ImageRecognitionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class ThresholdParameters : IAlgorithmParameter
    {
        public string AlgorithmName => "ThresholdAlgorithm";
        IAlgorithmParameterTemplate IAlgorithmParameter.ParameterTemplate => new ThresholdParametersTemplate();
        public int Threshold { get; set; }
        public int MaxValue { get; set; }
        public ThresholdTypes Type { get; set; }

    }

    [Flags]
    public enum ThresholdTypes
    {
        Binary = 0,
        BinaryInv = 1,
        Trunc = 2,
        Tozero = 3,
        TozeroInv = 4,
        Mask = 7,
        Otsu = 8,
        Triangle = 16
    }
}
