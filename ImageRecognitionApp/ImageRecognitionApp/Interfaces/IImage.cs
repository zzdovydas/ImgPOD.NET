using ImageRecognitionApp.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Interfaces
{
    public interface IImage : ICloneable
    {
        byte[] Image { get; set; }
        IImage ImageFromFile(string fileName);
    }
}
