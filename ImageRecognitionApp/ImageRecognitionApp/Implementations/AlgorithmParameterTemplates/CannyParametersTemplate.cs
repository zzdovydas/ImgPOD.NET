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
    internal class CannyParametersTemplate : IAlgorithmParameterTemplate
    {
        private NumericUpDown Threshold1;
        private NumericUpDown Threshold2;
        private NumericUpDown ApertureSize;
        private CheckBox L2Gradient;
        private CheckBox ProgressiveProcessing;

        public CannyParametersTemplate() 
        {
            Threshold1 = new NumericUpDown();
            Threshold2 = new NumericUpDown();
            ApertureSize = new NumericUpDown();
            L2Gradient = new CheckBox();
            ProgressiveProcessing = new CheckBox();
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(1200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            Threshold1.Location = new System.Drawing.Point(70, 10);
            Threshold1.Size = new System.Drawing.Size(150, 60);
            Threshold1 = Threshold1.MinMaxValue(0, 120).AllowOnlyIntValues();
            Threshold1.Value = 0;
            Threshold1.TabIndex = 0;

            Threshold2.Location = new System.Drawing.Point(70, 60);
            Threshold2.Size = new System.Drawing.Size(150, 60);
            Threshold2 = Threshold2.MinMaxValue(0, 1200).AllowOnlyIntValues();
            Threshold2.Value = 0;
            Threshold2.TabIndex = 0;

            ApertureSize.Location = new System.Drawing.Point(350, 60);
            ApertureSize.Size = new System.Drawing.Size(150, 60);
            ApertureSize = ApertureSize.MinMaxValue(0, 100).AllowOnlyIntValues();
            ApertureSize.Value = 0;
            ApertureSize.TabIndex = 0;

            L2Gradient.Location = new System.Drawing.Point(10, 80);
            L2Gradient.Size = new System.Drawing.Size(200, 50);
            L2Gradient.Text = "Enable L2Gradient";

            ProgressiveProcessing.Location = new System.Drawing.Point(250, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";

            p.Controls.AddSimpleLabel("Threshold1:", new Point(0, 15));
            p.Controls.AddSimpleLabel("Threshold2:", new Point(0, 65));
            p.Controls.AddSimpleLabel("ApertureSize:", new Point(250, 65));
            p.Controls.Add(Threshold1);
            p.Controls.Add(Threshold2);
            p.Controls.Add(ApertureSize);
            p.Controls.Add(L2Gradient);
            p.Controls.Add(ProgressiveProcessing);


            Threshold1.Value = 15;
            Threshold2.Value = 120;
            ApertureSize.Value = 3;
            L2Gradient.Checked = false;

            return p;
        }

        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                ProgressiveProcessing = this.ProgressiveProcessing.Checked,
                CannyParameters = new CannyParameters()
                {
                    Threshold1 = (int)this.Threshold1.Value,
                    Threshold2 = (int)this.Threshold2.Value,
                    ApertureSize = (int)this.ApertureSize.Value,
                    L2Gradient = L2Gradient.Checked
                }
            };
        }
    }
}
