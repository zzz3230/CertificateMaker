using Avalonia.Controls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CertificateMaker
{
    public partial class PreviewControl : UserControl
    {
        Scheme _scheme;
        Bitmap _sourceBitmap;
        SchemeDrawer _drawer;
        float _sizeMp;

        public PreviewControl()
        {
            InitializeComponent();
            _mainImage.PointerMoved += _mainImage_PointerMoved;
        }

        private void _mainImage_PointerMoved(object sender, Avalonia.Input.PointerEventArgs e)
        {
            var point = e.GetPosition(_mainImage);
            ;
            //_mousePosTextBlock.Text = "Image size: " + _mainImage.Source.Size.ToString();
        }

        public void Init(Scheme s, Bitmap sourceBitmap, SchemeDrawer drawer)
        {
            _scheme = s;
            const int width = 512; //128; 1024;

            float ratio = (float)sourceBitmap.Width / (float)sourceBitmap.Height;
            _sizeMp = (float)width / (float)sourceBitmap.Width;
            _sourceBitmap = new Bitmap(sourceBitmap, new Size(width, (int)(width / ratio))); // ;sourceBitmap;
            _drawer = drawer;
        }

        public void ReDraw()
        {
            var currentBitmap = _sourceBitmap.Clone(
                new Rectangle(0, 0, _sourceBitmap.Width, _sourceBitmap.Height),
                _sourceBitmap.PixelFormat
                );

            _scheme.ApplyToBitmap(currentBitmap, _drawer, _sizeMp);

            /*using (MemoryStream memory = new MemoryStream())
            {
                currentBitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                Avalonia.Media.Imaging.Bitmap AvIrBitmap = new Avalonia.Media.Imaging.Bitmap(memory);

                _mainImage.Source = AvIrBitmap;
            }*/
            _mainImage.Source = ImageExtensions.ConvertToAvaloniaBitmap(currentBitmap);
        }
    }
}
