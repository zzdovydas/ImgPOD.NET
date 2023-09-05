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
    internal class CropParametersTemplate : IAlgorithmParameterTemplate
    {
        private Button CropBoxFormButton;
        private Control CropBoxControl;
        private CropParameters Rectangle;
        private Image Image;

        private bool selectingCropArea = false;
        public CropParametersTemplate()
        {
            CropBoxFormButton = new Button();
            CropBoxControl = new Control();

            Image = Image.FromFile("mask.png");
        }
        public Control Draw()
        {
            Panel p = new Panel();
            p.Size = new System.Drawing.Size(200, 500);
            p.Location = new System.Drawing.Point(0, 0);
            p.BackColor = Color.Red;

            CropBoxFormButton.Text = "Open crop settings";
            CropBoxFormButton.Location = new Point(70, 10);

            CropBoxFormButton.Click += (e, s) =>
            {
                CropBoxControl = DrawCropBoxForm();
            };

            p.Controls.Add(CropBoxFormButton);

            return p;
        }
        public ImageProcessingParametersAbstraction GetParams()
        {
            return new ImageProcessingParametersAbstraction()
            {
                CropParameters = Rectangle
            };
        }

        public Control DrawCropBoxForm()
        {
            Form CropBoxForm = new Form();
            PictureBox CropBox = new PictureBox();
            Button CropBoxSubmitButton = new Button();

            CropBoxForm.Name = "Crop Image";
            CropBoxForm.Text = "Crop Image";
            CropBoxForm.Size = new Size() { Width = Image.Width, Height = Image.Height };

            CropBoxSubmitButton.Text = "Crop Image";
            CropBoxSubmitButton.Dock = DockStyle.Bottom;

            CropBoxSubmitButton.Click += (e, s) =>
            {
                CropBoxForm.Close();
            };

            CropBox.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectingCropArea = true;
                    Rectangle = new CropParameters() { X = e.X, Y = e.Y };
                }
            };

            CropBox.MouseMove += (s, e) =>
            {
                if (selectingCropArea)
                {
                    Rectangle.Width = e.X - Rectangle.X;
                    Rectangle.Height = e.Y - Rectangle.Y;
                    CropBox.Refresh();
                }
            };

            CropBox.Paint += (s, e) =>
            {
                if (!selectingCropArea)
                {
                    return;
                }

                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, new Rectangle() { X = Rectangle.X,
                                                                Y = Rectangle.Y,
                                                                Width = Rectangle.Width,
                                                                Height = Rectangle.Height});
            };

            CropBox.MouseUp += (s, e) =>
            {
                selectingCropArea = false;
            };

            CropBox.Image = Image.FromFile("mask.png");
            CropBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CropBox.Dock = DockStyle.Fill;

            CropBoxForm.Controls.Add(CropBox);
            CropBoxForm.Controls.Add(CropBoxSubmitButton);
            CropBoxForm.Show();

            return CropBoxForm;
        }
    }
}
