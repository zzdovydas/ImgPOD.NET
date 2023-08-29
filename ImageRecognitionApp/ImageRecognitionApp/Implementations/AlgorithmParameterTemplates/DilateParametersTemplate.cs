using ImageRecognitionApp.Extensions;
using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionApp.Implementations.AlgorithmParameterTemplates
{
    internal class DilateParametersTemplate : IAlgorithmParameterTemplate
    {
        private NumericUpDown AnchorX;
        private NumericUpDown AnchorY;
        private NumericUpDown Iterations;
        private OpenFileDialog ElementSelector;
        private CheckBox UseAnchorsCheckBox;
        private CheckBox ProgressiveProcessing;

        private IImage SelectedElement;

        public DilateParametersTemplate() 
        {
            AnchorX = new NumericUpDown();
            AnchorY = new NumericUpDown();
            Iterations = new NumericUpDown();
            ElementSelector = new OpenFileDialog();
            UseAnchorsCheckBox = new CheckBox();
            ProgressiveProcessing = new CheckBox();

            SelectedElement = null;
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(1200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            AnchorX.Location = new System.Drawing.Point(70, 10);
            AnchorX.Size = new System.Drawing.Size(150, 60);
            AnchorX = AnchorX.MinMaxValue(0, 120).AllowOnlyIntValues();
            AnchorX.Value = 0;
            AnchorX.TabIndex = 0;

            AnchorY.Location = new System.Drawing.Point(70, 60);
            AnchorY.Size = new System.Drawing.Size(150, 60);
            AnchorY = AnchorY.MinMaxValue(0, 1200).AllowOnlyIntValues();
            AnchorY.Value = 0;
            AnchorY.TabIndex = 0;

            UseAnchorsCheckBox.Location = new System.Drawing.Point(250, 10);
            UseAnchorsCheckBox.Size = new System.Drawing.Size(200, 50);
            UseAnchorsCheckBox.Text = "Enable Anchor";
            UseAnchorsCheckBox.CheckedChanged += UseAnchorsCheckBox_CheckedChanged;

            Iterations.Location = new System.Drawing.Point(320, 10);
            Iterations.Size = new System.Drawing.Size(150, 60);
            Iterations = Iterations.MinMaxValue(0, 100).AllowOnlyIntValues();
            Iterations.Value = 0;
            Iterations.TabIndex = 0;

            Button fileSelectorButton = new Button();
            fileSelectorButton.Location = new System.Drawing.Point(250, 60);
            fileSelectorButton.Text = "Select element image";
            fileSelectorButton.Click += FileSelectorButton_Click;

            ElementSelector.Multiselect = false;
            ElementSelector.FileOk += FileSelected_Click;

            ProgressiveProcessing.Location = new System.Drawing.Point(10, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";

            p.Controls.AddSimpleLabel("AnchorX:", new Point(0, 15));
            p.Controls.AddSimpleLabel("AnchorY:", new Point(0, 65));
            p.Controls.AddSimpleLabel("Iterations:", new Point(250, 15));
            p.Controls.Add(AnchorX);
            p.Controls.Add(AnchorY);
            p.Controls.Add(Iterations);
            p.Controls.Add(fileSelectorButton);
            p.Controls.Add(ProgressiveProcessing);

            return p;
        }
        private void UseAnchorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool currState = UseAnchorsCheckBox.Checked;
            ChangeAnchorState(currState);
        }
        private void ChangeAnchorState(bool state)
        {
            AnchorX.Enabled = state;
            AnchorY.Enabled = state;
        }
        private void FileSelectorButton_Click(object sender, EventArgs e)
        {
            ElementSelector.ShowDialog();
        }
        private void FileSelected_Click(object sender, CancelEventArgs e)
        {
            string filePath = ElementSelector.FileName;

            if (File.Exists(filePath))
            {
                try
                {
                    SelectedElement = new ImageImpl();
                    SelectedElement.Image = File.ReadAllBytes(filePath);
                    MessageBox.Show("Selected file as element with path: " + filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                ProgressiveProcessing = this.ProgressiveProcessing.Checked,
                DilateParameters = new DilateParameters()
                {
                    AnchorX = (int)this.AnchorX.Value,
                    AnchorY = (int)this.AnchorY.Value,
                    Iterations = (int)this.Iterations.Value,
                    Element = SelectedElement,
                }
            };
        }
    }
}
