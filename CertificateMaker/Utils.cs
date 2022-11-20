using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateMaker
{
    internal static class Utils
    {
        public static PointF Multiply(this PointF a, float b)
        {
            return new PointF(a.X * b, a.Y * b);
        }

        public static string GetCurrentDir()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
    }
}
