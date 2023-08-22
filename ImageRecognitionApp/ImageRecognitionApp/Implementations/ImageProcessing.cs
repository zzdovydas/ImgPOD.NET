﻿using ImageRecognitionApp.Implementations.ImageProcessing;
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
    internal class ImageProcessingImpl
    {
        private readonly List<IImageProcessingAlgorithm> algorithms;
        public ImageProcessingImpl() 
        {
            algorithms = new List<IImageProcessingAlgorithm>
            {
                new Implementations.ImageProcessing.BlurProcessing()
            };
        }

        public IImageProcessingAlgorithm ProcessImageByAlgorithm(string algorithm)
        {
            foreach (var a in algorithms)
            {
                if (algorithm == a.AlgorithmName)
                {
                    return a;
                }
            }

            return null;
        }
    }
}