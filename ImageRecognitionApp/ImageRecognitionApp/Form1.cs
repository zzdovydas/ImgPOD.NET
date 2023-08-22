using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageRecognitionApp.Utils.ImageProcessing;
using ImageRecognitionApp.Interfaces.ImageProcessing;
using ImageRecognitionApp.Implementations.ImageProcessing;
using ImageRecognitionApp.Implementations;
using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Models.ImageProcessingParameters;

namespace ImageRecognitionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaskImage();
        }

        public void MaskImage()
        {
            IImage srcImage = new ImageImpl();
            srcImage.ImageFromFile("5.png");

            var imageProcessingImpl = new ImageProcessingImpl();
            IImageProcessingAlgorithm blurAlgorithm = imageProcessingImpl.ProcessImageByAlgorithm("BlurAlgorithm");
            IImage result = blurAlgorithm.ProcessImage(srcImage, new ImageProcessingParametersAbstraction()
            {
                BlurParameters = new BlurParameters()
                {
                    KSize = 9,
                    Sigma = 0
                }
            });

            pictureBox5.Image = ImageProcessingHelpers.ByteArrayToBitmap(result.Image);




            string inputFileNameMask = "4.png";
            string inputFileName = "5.png";
            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputFileName)}-gray.jpg";
            using (var image = new Mat(inputFileName))
            using (var gray = image.CvtColor(ColorConversionCodes.BGRA2GRAY))
            {
                var mask = new Mat(inputFileNameMask);
                mask = mask.CvtColor(ColorConversionCodes.BGRA2GRAY);

                pictureBox1.Image = ImageProcessingHelpers.ByteArrayToBitmap(image.ToBytes());

                var blur = new Mat();
                Cv2.GaussianBlur(mask, mask, new OpenCvSharp.Size(9, 9), 0);

                Cv2.GaussianBlur(gray, blur, new OpenCvSharp.Size(9, 9), 0);
                pictureBox2.Image = ImageProcessingHelpers.ByteArrayToBitmap(blur.ToBytes());

                var diff = new Mat();
                Cv2.Absdiff(blur, mask, blur);
                //Cv2.Threshold(blur, blur, 38, 150, ThresholdTypes.Binary);

                var canny = new Mat();
                Cv2.Canny(blur, canny, 15, 120);
                pictureBox3.Image = ImageProcessingHelpers.ByteArrayToBitmap(canny.ToBytes());

                Cv2.Dilate(canny, canny, new Mat(), null, 1);
                pictureBox4.Image = ImageProcessingHelpers.ByteArrayToBitmap(canny.ToBytes());

                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchyIndexes;

                Cv2.FindContours(canny, out contours, out hierarchyIndexes, mode: RetrievalModes.External,
                    method: ContourApproximationModes.ApproxSimple);

                foreach (var c in contours)
                {
                    var rect = Cv2.BoundingRect(c);
                    Cv2.Rectangle(image, new OpenCvSharp.Point(rect.X, rect.Y), new OpenCvSharp.Point(rect.X + rect.Width,
                        rect.Y + rect.Height), Scalar.DarkRed, 2);
                }

                Bitmap finalImg = ImageProcessingHelpers.ByteArrayToBitmap(image.ToBytes());
                //pictureBox5.Image = finalImg;
                image.SaveImage(outputFileName);
            }
        }



        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
