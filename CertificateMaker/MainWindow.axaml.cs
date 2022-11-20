using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Drawing.Imaging;
using System.IO;
using MessageBox.Avalonia;

namespace CertificateMaker
{
    public partial class MainWindow : Window
    {


        void LoadImage(string path)
        {
            System.Drawing.Bitmap irBitmap = new System.Drawing.Bitmap(
                   path
               );
            _drawer.sourceBitmap = irBitmap;
            _testPreview.Init(_scheme, irBitmap, _drawer);
            _testPreview.ReDraw();
        }

        private void AddTextElement_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddTextElement();
        }

        private async void ExportByCsv_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog { };
                dialog.Filters.Add(new FileDialogFilter { Name = "csv file", Extensions = new() { "csv", } });
                var res = await dialog.ShowAsync(this);
                if (res != null && res.Length > 0)
                {
                    var dir = Utils.GetCurrentDir() + @"\_out\";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    _drawer.ApplySchemeToCsv(res[0], dir);
                }
            }
            catch(Exception ex)
            {
                var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow("Error", ex.StackTrace + "\n" + ex.Message);
                await messageBoxStandardWindow.Show();
            }
        }

        private async void OpenImage_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { };
            dialog.Filters.Add(new FileDialogFilter { Name = "image", Extensions = new() { "jpg", "png", "bmp", "jpeg" } });
            var res = await dialog.ShowAsync(this);
            if(res != null && res.Length > 0)
                LoadImage(res[0]);
        }

        void AddTextElement()
        {
            var textEl = new SchemeTextElement();
            _scheme.AddElement(textEl);

            var textElControl = new TextElementPropsControl();
            textElControl.Init(textEl, _testPreview);
            _propsPanel.Children.Add(textElControl);
        }

        SchemeDrawer _drawer;
        Scheme _scheme;

        public MainWindow()
        {
            InitializeComponent();

            Canvas.SetLeft(_propsPanel, 10);
            Canvas.SetRight(_previewPanel, 10);

            _scheme = new Scheme();
            _drawer = new SchemeDrawer();
            _drawer.scheme = _scheme;

            //this.toolbar

            //var image = new Avalonia.Media.Imaging.Bitmap(@"C:\Users\MasterKlass\Desktop\test_image.jpg");
            /*System.Drawing.Bitmap irBitmap = new System.Drawing.Bitmap(
                @"C:\Users\zzz32\source\repos\CertificateMaker\CertificateMaker\5c43cf67f23274fd241372c72ee154a5b6357f53.png"
            );*/

            /*var s = new Scheme();
            _testPreview.Init(s, irBitmap);

            var textEl = new SchemeTextElement();
            textEl.x = 10;
            textEl.y = 20;
            _testTextProps.Init(textEl, _testPreview);
            s.AddElement(textEl);*/


            /*s.ApplyToBitmap(irBitmap);

            using (MemoryStream memory = new MemoryStream())
            {
                irBitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                Avalonia.Media.Imaging.Bitmap AvIrBitmap = new Avalonia.Media.Imaging.Bitmap(memory);

                var newImage = new Image();
                newImage.Source = AvIrBitmap;
                newImage.Width = 500;
                //newImage.Height = 100;

                _mainCanvas.Children.Add(newImage);
                Canvas.SetRight(newImage, 100);
                Canvas.SetTop(newImage, 100);
            }
            ;
            */

        }

    }
}
