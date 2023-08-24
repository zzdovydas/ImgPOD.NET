using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Interfaces
{
    internal interface IAlgorithmParameter
    {
        string AlgorithmName { get; }
        IAlgorithmParameterTemplate ParameterTemplate { get; }
    }
}
