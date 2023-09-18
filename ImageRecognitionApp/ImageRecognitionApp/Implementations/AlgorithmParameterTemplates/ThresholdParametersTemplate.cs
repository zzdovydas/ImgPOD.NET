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
    internal class ThresholdParametersTemplate : IAlgorithmParameterTemplate
    {
        private NumericUpDown Threshold;
        private NumericUpDown MaxValue;
        private ComboBox Type;
        private CheckBox ProgressiveProcessing;

        public ThresholdParametersTemplate() 
        {
            Threshold = new NumericUpDown();
            MaxValue = new NumericUpDown();
            Type = new ComboBox();
            ProgressiveProcessing = new CheckBox();
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(1200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            Threshold.Location = new System.Drawing.Point(70, 10);
            Threshold.Size = new System.Drawing.Size(150, 60);
            Threshold = Threshold.MinMaxValue(0, 255).AllowOnlyIntValues();
            Threshold.Value = 0;
            Threshold.TabIndex = 0;

            MaxValue.Location = new System.Drawing.Point(70, 60);
            MaxValue.Size = new System.Drawing.Size(150, 60);
            MaxValue = MaxValue.MinMaxValue(0, 100).AllowOnlyIntValues();
            MaxValue.Value = 0;
            MaxValue.TabIndex = 0;

            Type.Location = new System.Drawing.Point(350, 10);
            Type.Size = new System.Drawing.Size(150, 60);
            Type.TabIndex = 0;

            ThresholdTypes types = new ThresholdTypes();
            foreach (Enum type in Enum.GetValues(types.GetType()))
            {
                Type.Items.Add(new ComboBoxThresholdType() { Text = type.ToString(), Value = Convert.ToInt32(type) });
            }

            ProgressiveProcessing.Location = new System.Drawing.Point(10, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";

            p.Controls.AddSimpleLabel("Threshold:", new Point(0, 15));
            p.Controls.AddSimpleLabel("MaxValue:", new Point(0, 65));
            p.Controls.AddSimpleLabel("ThresholdType:", new Point(250, 10));
            p.Controls.Add(Threshold);
            p.Controls.Add(MaxValue);
            p.Controls.Add(Type);
            p.Controls.Add(ProgressiveProcessing);

            Threshold.Value = 120;

            return p;
        }

        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                ProgressiveProcessing = ProgressiveProcessing.Checked,
                ThresholdParameters = new ThresholdParameters()
                {
                    Threshold = (int)this.Threshold.Value,
                    Type = (ThresholdTypes)((ComboBoxThresholdType)this.Type.SelectedItem).Value,
                    MaxValue = (int)this.MaxValue.Value,
                }
            };
        }

        public class ComboBoxThresholdType
        {
            public object Value { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
