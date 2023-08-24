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
    internal class BlurParametersTemplate : IAlgorithmParameterTemplate
    {
        private NumericUpDown KSize;
        private NumericUpDown Sigma;
        private CheckBox ProgressiveProcessing;

        public BlurParametersTemplate() 
        {
            KSize = new NumericUpDown();
            Sigma = new NumericUpDown();
            ProgressiveProcessing = new CheckBox();
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            KSize.Location = new System.Drawing.Point(50, 10);
            KSize.Size = new System.Drawing.Size(150, 60);
            KSize = KSize.MinMaxValue(0, 100).AllowOnlyIntValues();
            KSize.Value = 0;
            KSize.TabIndex = 0;

            Sigma.Location = new System.Drawing.Point(50, 60);
            Sigma.Size = new System.Drawing.Size(150, 60);
            Sigma = Sigma.MinMaxValue(0, 100).AllowOnlyIntValues();
            Sigma.Value = 0;
            Sigma.TabIndex = 0;

            ProgressiveProcessing.Location = new System.Drawing.Point(10, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";

            p.Controls.AddSimpleLabel("KSize:", new Point(0, 15));
            p.Controls.AddSimpleLabel("Sigma:", new Point(0, 65));
            p.Controls.Add(KSize);
            p.Controls.Add(Sigma);
            p.Controls.Add(ProgressiveProcessing);


            KSize.Value = 3;

            return p;
        }

        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                ProgressiveProcessing = ProgressiveProcessing.Checked,
                BlurParameters = new BlurParameters()
                {
                    KSize = (int)this.KSize.Value,
                    Sigma = (int)this.Sigma.Value,
                }
            };
        }
    }
}
