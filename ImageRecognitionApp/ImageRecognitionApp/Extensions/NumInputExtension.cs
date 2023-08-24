using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionApp.Extensions
{
    public static class NumInputExtension
    {
        public static NumericUpDown MinMaxValue(this NumericUpDown n, decimal min, decimal max)
        {
            n.Minimum = min;
            n.Maximum = max;

            return n;
        }

        public static NumericUpDown AllowOnlyIntValues(this NumericUpDown n)
        {
            n.DecimalPlaces = 0;
            return n;
        }
    }
}
