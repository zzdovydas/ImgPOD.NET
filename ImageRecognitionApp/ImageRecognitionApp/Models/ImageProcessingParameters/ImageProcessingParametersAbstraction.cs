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
        public DilateParameters DilateParameters { get; set; }
        public MaskParameters MaskParameters { get; set; }
        public CropParameters CropParameters { get; set; }
        public ThresholdParameters ThresholdParameters { get; set; }
    }
}
