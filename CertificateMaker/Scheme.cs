using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateMaker
{
    public class Scheme
    {
        List<SchemeElement> _elements = new();
        public IEnumerable<SchemeElement> elements => _elements;

        public void AddElement(SchemeElement el)
        {
            _elements.Add(el);
            el.SetScheme(this);
        }
        public void RemoveElement(SchemeElement el)
        {
            _elements.Remove(el);
            el.SetScheme(null);
        }

        public void ApplyToBitmap(Bitmap bitmap, SchemeDrawer drawer, float sizeMp, Dictionary<string, object> customParams = null)
        {
            var grap = Graphics.FromImage(bitmap);
            for (int i = 0; i < _elements.Count; i++)
            {
                _elements[i].ApplyToGraphics(grap, drawer, sizeMp, customParams);
            }
        }
    }
}
