using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateMaker
{
    public class SchemeElement
    {
        public float x;
        public float y;
        public string id;
        protected Scheme _scheme;

        public void SetScheme(Scheme s) => _scheme = s;
        virtual public void ApplyToGraphics(Graphics graph, SchemeDrawer drawer, float sizeMp, Dictionary<string, object> customParams)
        {
        }
    }
}
