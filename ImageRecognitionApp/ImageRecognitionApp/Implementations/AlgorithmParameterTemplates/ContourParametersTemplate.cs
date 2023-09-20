using ImageRecognitionApp.Extensions;
using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionApp.Implementations.AlgorithmParameterTemplates
{
    internal class ContourParametersTemplate : IAlgorithmParameterTemplate
    {
        private CheckBox ProgressiveProcessing;

        public ContourParametersTemplate() 
        {
            ProgressiveProcessing = new CheckBox();
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(1200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            ProgressiveProcessing.Location = new System.Drawing.Point(10, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";

            p.Controls.Add(ProgressiveProcessing);

            return p;
        }

        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                ProgressiveProcessing = ProgressiveProcessing.Checked,
                ContourParameters = new ContourParameters()
            };
        }
    }
}
