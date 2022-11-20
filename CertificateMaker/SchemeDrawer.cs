using CsvHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateMaker
{
    public class SchemeDrawer
    {
        public Bitmap sourceBitmap;
        public Scheme scheme;

        public PointF ConvertNormalizedToAbsolute(PointF pos)
        {
            return new(sourceBitmap.Width * pos.X, sourceBitmap.Height * pos.Y);
        }

        List<Dictionary<string, object>> ReadCsv(string pathToCsv)
        {
            List<Dictionary<string, object>> result = new();

            using (var reader = new StreamReader(pathToCsv))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                var headers = csv.HeaderRecord;

                while (csv.Read())
                {
                    result.Add(new());
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var value = csv.GetField(headers[i]);
                        result.Last().Add(headers[i], value);   
                    }
                }
            }
            return result;
        }

        public void ApplySchemeToCsv(string pathToCsv, string outDir)
        {
            var csvParams = ReadCsv(pathToCsv);
            for (int i = 0; i < csvParams.Count; i++)
            {
                var currentBitmap = sourceBitmap.Clone(
                    new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                    sourceBitmap.PixelFormat
                );
                scheme.ApplyToBitmap(currentBitmap, this, 1, csvParams[i]);
                File.WriteAllText(outDir + $"image_{i}.jpg", "empty");
                currentBitmap.Save(outDir + $"image_{i}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                currentBitmap.Dispose();
            }
        }
    }
}
