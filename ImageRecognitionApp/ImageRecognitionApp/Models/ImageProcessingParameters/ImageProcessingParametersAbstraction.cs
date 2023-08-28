using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Models.ImageProcessingParameters
{
    public class ImageProcessingParametersAbstraction
    {
        public bool ProgressiveProcessing;
        public BlurParameters BlurParameters { get; set; }
        public CannyParameters CannyParameters { get; set; }
    }
}
