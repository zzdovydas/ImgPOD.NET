using Emgu.CV;
using Emgu.CV.Structure;
using ImageRecognitionApp.Implementations;
using ImageRecognitionApp.Interfaces;
using System.Collections.Generic;

namespace ImageRecognitionApp.Utils
{
    internal static class VideoToImagesConverter
    {
        internal static List<IImage> ConvertByPathName(string filePath)
        {
            List<IImage> result = new List<IImage>();
            int counter = 0;

            using (var video = new VideoCapture(filePath))
            {
                using (var img = new Mat())
                {
                    while (video.Grab())
                    {
                        video.Set(Emgu.CV.CvEnum.CapProp.PosFrames, counter);
                        video.Retrieve(img);
                        result.Add(new ImageImpl() { Image = img.ToImage<Bgr, byte>().ToJpegData() });
                        counter += 30;
                    }
                }

            }

            return result;
        }
    }
}
