using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionApp.Models
{
    public class ImageProcessingAction
    {
        public ImageProcessingParametersAbstraction Parameters;
        public string AlgorithmName;
        public Control ActionDisplayElement;
    }
}
