using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.Control;
using System.Reflection.Emit;

namespace ImageRecognitionApp.Extensions
{
    public static class ControlCollectionExtension
    {
        public static void AddSimpleLabel(this ControlCollection c, string text, Point location)
        {
            Control label = new System.Windows.Forms.Label();

            label.Text = text;
            label.Location = location;
            label.Size = TextRenderer.MeasureText(label.Text, label.Font);

            c.Add(label);
        }
    }
}
