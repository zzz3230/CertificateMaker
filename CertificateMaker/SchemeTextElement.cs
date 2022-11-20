using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateMaker
{
    public class SchemeTextElement : SchemeElement
    {
        public string defaultValue;
        public float fontSize;
        public string fontName;
        public string alignment;
        public FontStyle style;
        public Color color;

        public override void ApplyToGraphics(Graphics graph, SchemeDrawer drawer, float sizeMp, Dictionary<string, object> customParams)
        {
            //new Font("Courier new", 35)
            //graph.DpiX Color.Red

            StringFormat format = new StringFormat();

            format.LineAlignment = alignment switch
            {
                "Left" => StringAlignment.Near,
                "Center" => StringAlignment.Center,
                "Right" => StringAlignment.Far,
                _ => throw new Exception($"{alignment} is not alignment")
            };

            format.Alignment = format.LineAlignment;

            graph.DrawString(
                customParams == null ? defaultValue ?? "hello" : (string)customParams[id], 
                new Font(fontName, (fontSize < 1 ? 1 : fontSize) * sizeMp, style, GraphicsUnit.World),
                new SolidBrush(color), 
                drawer.ConvertNormalizedToAbsolute(new PointF(x, y)).Multiply(sizeMp),
                format
                ); 
        }
    }
}
