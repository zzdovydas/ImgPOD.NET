using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Interfaces.ImageProcessing;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Implementations
{
    internal class ImageParametersImpl
    {
        private readonly List<IAlgorithmParameter> parameters;
        public ImageParametersImpl()
        {
            parameters = new List<IAlgorithmParameter>
            {
                new BlurParameters(),
                new CannyParameters(),
                new DilateParameters(),
                new MaskParameters(),
                new CropParameters(),
                new ThresholdParameters(),
                new ContourParameters(),
            };
        }

        public IAlgorithmParameter GetParametersByAlgorithm(string algorithm)
        {
            foreach (var p in parameters)
            {
                if (algorithm == p.AlgorithmName)
                {
                    return p;
                }
            }

            return null;
        }

    }
}
