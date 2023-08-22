﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionApp.Interfaces
{
    internal interface IImage
    {
        byte[] Image { get; set; }
        IImage ImageFromFile(string fileName);
    }
}