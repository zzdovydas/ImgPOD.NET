using ImageRecognitionApp.Interfaces;
using ImageRecognitionApp.Interfaces.ImageProcessing;
using ImageRecognitionApp.Models;
using ImageRecognitionApp.Models.ImageProcessingParameters;
using ImageRecognitionApp.Utils.ImageProcessing;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Implementations.ImageProcessing
{
    // https://github.com/shimat/opencvsharp/issues/173
    internal class ContoursProcessing : IImageProcessingAlgorithm
    {
        public string AlgorithmName => "ContoursAlgorithm"; 
            
        public IImage ProcessImage(IImage sourceImg, ImageProcessingParametersAbstraction parameters)
        {
            Mat src = Cv2.ImDecode(sourceImg.Image, ImreadModes.Color);
            ThresholdParameters p = parameters.ThresholdParameters;

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Mat contouredImg = src.CvtColor(ColorConversionCodes.BGR2GRAY);

            Cv2.FindContours(contouredImg, out contours, out hierarchyIndexes, mode: RetrievalModes.External, method: ContourApproximationModes.ApproxSimple);
            
            foreach (var c in contours)
            {
                var rect = Cv2.BoundingRect(c);
                Cv2.Rectangle(src, new OpenCvSharp.Point(rect.X, rect.Y), new OpenCvSharp.Point(rect.X + rect.Width,
                    rect.Y + rect.Height), Scalar.DarkRed, 2);
            }

            IImage result = new ImageImpl() { Image = src.ToBytes() };

            return result;
        }
    }
}
