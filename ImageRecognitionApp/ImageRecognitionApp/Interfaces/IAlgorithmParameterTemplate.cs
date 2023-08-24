using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ImageRecognitionApp.Interfaces
{
    // Template interface to display Image processing algorithm parameters GUI.
    // Limited to Windows only
    internal interface IAlgorithmParameterTemplate
    {
        Control Draw();
        ImageProcessingParametersAbstraction GetParams();
    }
}
