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
    public class MaskParametersTemplate : IAlgorithmParameterTemplate
    {
        private OpenFileDialog ElementSelector;
        private CheckBox ProgressiveProcessing;

        private IImage SelectedElement;

        public MaskParametersTemplate()
        {
            ElementSelector = new OpenFileDialog();
            ProgressiveProcessing = new CheckBox();

            SelectedElement = null;
        }

        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(1200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            Button fileSelectorButton = new Button();
            fileSelectorButton.Location = new System.Drawing.Point(70, 10);
            fileSelectorButton.Text = "Select mask image";
            fileSelectorButton.Click += FileSelectorButton_Click;

            ElementSelector.Multiselect = false;
            ElementSelector.FileOk += FileSelected_Click;

            ProgressiveProcessing.Location = new System.Drawing.Point(10, 80);
            ProgressiveProcessing.Size = new System.Drawing.Size(200, 50);
            ProgressiveProcessing.Text = "Enable progressive processing";


            p.Controls.AddSimpleLabel("Select mask:", new Point(0, 15));
            p.Controls.Add(fileSelectorButton);
            p.Controls.Add(ProgressiveProcessing);

            return p;
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
                MaskParameters = new MaskParameters()
                {
                    Mask = SelectedElement,
                }
            };
        }
    }
}
