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
using ImageRecognitionApp.Models;
using ImageRecognitionApp.Utils;
using ImageRecognitionApp.Extensions;

namespace ImageRecognitionApp
{
    public partial class MainForm : Form
    {
        private readonly ImageProcessingImpl imageProcessingImpl;
        private List<ImageProcessingAction> imageProcessingActions;
        private List<IImage> selectedImageList;
        private Bitmap selectedImageToSave;

        private List<Panel> actionControls;
        private List<PictureBox> imageControls;

        private List<List<Bitmap>> imageResults;
        private IAlgorithmParameterTemplate selectedParameters;

        public MainForm()
        {
            InitializeComponent();

            imageProcessingImpl = new ImageProcessingImpl();
            imageProcessingActions = new List<ImageProcessingAction>();
            selectedImageToSave = null;
            selectedImageList = new List<IImage>();
            imageResults = new List<List<Bitmap>>();

            actionControls = new List<Panel>();
            imageControls = new List<PictureBox>();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string algorithm = AlgorithmSelectBox.SelectedItem?.ToString();

            if (algorithm == null)
            {
                MessageBox.Show("Please select algorithm from the select box!", "Algorithm is not selected!", MessageBoxButtons.OK);
                return;
            }

            if (selectedParameters == null)
            {
                return;
            }

            ImageProcessingParametersAbstraction p = selectedParameters.GetParams();

            string name = AlgorithmSelectBox.SelectedItem.ToString();
            var action = new ImageProcessingAction() { AlgorithmName = name, Parameters = p};

            imageProcessingActions.Add(action);
            RedrawActions();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAlgorithmsToSelectBox();
        }

        private void LoadAlgorithmsToSelectBox()
        {
            string[] algorithms = imageProcessingImpl.GetAllAvailableAlgorithmNames();
            AlgorithmSelectBox.Items.AddRange(algorithms);
        }

        private void StartImageProcessingButton_Click(object sender, EventArgs e)
        {
            DestroyPreviousImageControls();
            ProcessImagesByAlgorithms();
            DrawResultPictureBoxes();
        }

        private void ProcessImagesByAlgorithms()
        {
            foreach (var srcImage in selectedImageList)
            {
                IImage tempImage = (IImage)srcImage.Clone();
                List<Bitmap> resultImageList = new List<Bitmap>();

                resultImageList.Add(ImageProcessingHelpers.ByteArrayToBitmap(tempImage.Image));

                foreach (var a in imageProcessingActions)
                {
                    try
                    {
                        if (a.Parameters.ProgressiveProcessing)
                        {
                            tempImage = (IImage)srcImage.Clone();
                        }

                        IImageProcessingAlgorithm ipa = imageProcessingImpl.ProcessImageByAlgorithm(a.AlgorithmName);
                        IImage result = ipa.ProcessImage(tempImage, a.Parameters);

                        resultImageList.Add(ImageProcessingHelpers.ByteArrayToBitmap(result.Image));

                        tempImage = result;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                imageResults.Add(resultImageList);
            }
        }
        private void DestroyPreviousImageControls()
        {
            imageControls = new List<PictureBox>();
            imageResults = new List<List<Bitmap>>();
            ImageResultsPanel.Controls.Clear();
        }

        private void DrawResultPictureBoxes()
        {
            int x = 20;
            int y = 20;
            int width = 600;
            int height = 450;
            int xSpacing = 10;

            foreach (var r in imageResults)
            {
                foreach (var picture in r)
                {
                    PictureBox p = new PictureBox();
                    p.Image = picture;
                    p.Location = new System.Drawing.Point(x, y);
                    p.Size = new System.Drawing.Size(width - xSpacing, height);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;

                    p.Click += (s, e) => {
                        selectedImageToSave = picture;
                        saveImageDialog.ShowDialog();
                    };

                    ImageResultsPanel.Controls.Add(p);
                    imageControls.Add(p);

                    x += width;
                }

                y += 500;
                x = 20;
            }
        }

        private void RedrawActions()
        {
            ClearActions();

            int x = 20;
            int y = 20;
            int width = 160;
            int xSpacing = 10;

            for (int i = 0; i < imageProcessingActions.Count; i++)
            {
                var a = imageProcessingActions[i];

                Panel p = new Panel();
                p.Size = new System.Drawing.Size(width - xSpacing, 20);
                p.Location = new System.Drawing.Point(x, y);
                p.BackColor = Color.Red;

                Label l = new Label();
                l.Size = new System.Drawing.Size(width - xSpacing, 20);
                l.Location = new System.Drawing.Point(0, 0);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Text = a.AlgorithmName;
                l.Tag = i;

                l.MouseEnter += (s, e) => { l.Text = "Click to remove"; };
                l.MouseLeave += (s, e) => { l.Text = a.AlgorithmName; };

                l.Click += (s, e) => { 
                    imageProcessingActions.RemoveAt((int)l.Tag);
                    RedrawActions();
                };

                p.Controls.Add(l);
                groupBox1.Controls.Add(p);
                x += width;


            }
        }

        private void ClearActions()
        {
            groupBox1.Controls.Clear();
        }

        public void MaskImage()
        {
            IImage srcImage = new ImageImpl();
            srcImage.ImageFromFile("5.png");

            IImageProcessingAlgorithm blurAlgorithm = imageProcessingImpl.ProcessImageByAlgorithm("BlurAlgorithm");
            //IImage result = blurAlgorithm.ProcessImage(srcImage, );

            //pictureBox5.Image = ImageProcessingHelpers.ByteArrayToBitmap(result.Image);




            string inputFileNameMask = "4.png";
            string inputFileName = "5.png";
            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputFileName)}-gray.jpg";
            using (var image = new Mat(inputFileName))
            using (var gray = image.CvtColor(ColorConversionCodes.BGRA2GRAY))
            {
                var mask = new Mat(inputFileNameMask);
                mask = mask.CvtColor(ColorConversionCodes.BGRA2GRAY);

                //pictureBox1.Image = ImageProcessingHelpers.ByteArrayToBitmap(image.ToBytes());

                var blur = new Mat();
                Cv2.GaussianBlur(mask, mask, new OpenCvSharp.Size(9, 9), 0);

                Cv2.GaussianBlur(gray, blur, new OpenCvSharp.Size(9, 9), 0);
                //pictureBox2.Image = ImageProcessingHelpers.ByteArrayToBitmap(blur.ToBytes());

                var diff = new Mat();
                Cv2.Absdiff(blur, mask, blur);
                Cv2.Threshold(blur, blur, 38, 150, OpenCvSharp.ThresholdTypes.Binary);

                var canny = new Mat();
                Cv2.Canny(blur, canny, 15, 120);
                //pictureBox3.Image = ImageProcessingHelpers.ByteArrayToBitmap(canny.ToBytes());

                Cv2.Dilate(canny, canny, new Mat(), null, 1);
                //pictureBox4.Image = ImageProcessingHelpers.ByteArrayToBitmap(canny.ToBytes());

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

        private void AlgorithmSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();

            var parametersImpl = new ImageParametersImpl();
            IAlgorithmParameter p = parametersImpl.GetParametersByAlgorithm(AlgorithmSelectBox.SelectedItem.ToString());
            var template = p.ParameterTemplate;
            selectedParameters = template;

            groupBox2.Controls.Add(template.Draw());
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadVideoButton_Click(object sender, EventArgs e)
        {
            List<IImage> videoImages = VideoToImagesConverter.ConvertByPathName("video.mp4");
            selectedImageList.AddRange(videoImages);
        }

        private void AddToImageList(List<IImage> list)
        {

        }

        private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (selectedImageToSave == null) 
            {
                MessageBox.Show("Error! Image is not selected!");
                return;
            }

            var bytes = selectedImageToSave.ToBytes(ImageFormat.Png);
            File.WriteAllBytes(saveImageDialog.FileName, bytes);
        }
    }
}
