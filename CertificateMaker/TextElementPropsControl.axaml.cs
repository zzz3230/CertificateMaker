using Avalonia.Controls;

namespace CertificateMaker
{
    public partial class TextElementPropsControl : UserControl
    {
        SchemeTextElement _element;
        PreviewControl _previewControl;
        public TextElementPropsControl()
        {
            InitializeComponent();
            

            _xNum.ValueChanged += _xNum_ValueChanged;
            _yNum.ValueChanged += _yNum_ValueChanged;
            _idTextBox.KeyUp += _idTextBox_KeyUp;
            _defTextBox.KeyUp += _defTextBox_KeyUp;
            _fontComboBox.SelectionChanged += _fontComboBox_SelectionChanged;
            _sizeNum.ValueChanged += _sizeNum_ValueChanged;
            _alignmentComboBox.SelectionChanged += _alignmentComboBox_SelectionChanged;
            _styleComboBox.SelectionChanged += _styleComboBox_SelectionChanged;
            //_colorPicker.KeyUp += _colorPicker_KeyUp;
            //_colorPicker.PointerPressed += _colorPicker_PointerPressed;
            _applyButton.Click += _applyButton_Click;
        }

        private void _applyButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SyncValues();
        }

        private void _colorPicker_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            SyncValues();
        }

        private void _colorPicker_KeyUp(object sender, Avalonia.Input.KeyEventArgs e)
        {
            SyncValues();
        }

        private void _styleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncValues();
        }

        private void _alignmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncValues();
        }

        public void Init(SchemeTextElement el, PreviewControl p)
        {
            _element = el;
            _previewControl = p;
            SyncValues();
        }

        void SyncValues()
        {
            _element.x = (float)_xNum.Value;
            _element.y = (float)_yNum.Value;
            _element.id = _idTextBox.Text;
            _element.defaultValue = _defTextBox.Text;
            _element.fontName = (((ComboBoxItem)_fontComboBox.SelectedItem)?.Content ?? "Courier new").ToString();
            _element.fontSize = (float)_sizeNum.Value;
            _element.alignment = (((ComboBoxItem)_alignmentComboBox.SelectedItem)?.Content ?? "Left").ToString();

            System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;
            foreach (var st in (((ComboBoxItem)_styleComboBox.SelectedItem)?.Content ?? "Regular").ToString().Split('+'))
            {
                style |= System.Enum.Parse<System.Drawing.FontStyle>(st, true);
            }
            _element.style = style;

            _element.color = System.Drawing.Color.FromArgb(_colorPicker.Color.A, _colorPicker.Color.R, _colorPicker.Color.G, _colorPicker.Color.B);

            _previewControl.ReDraw();
        }

        private void _sizeNum_ValueChanged(object sender, NumericUpDownValueChangedEventArgs e)
        {
            SyncValues();
        }
        private void _fontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncValues();
        }
        private void _defTextBox_KeyUp(object sender, Avalonia.Input.KeyEventArgs e)
        {
            SyncValues();
        }
        private void _idTextBox_KeyUp(object sender, Avalonia.Input.KeyEventArgs e)
        {
            SyncValues();
        }
        private void _yNum_ValueChanged(object sender, NumericUpDownValueChangedEventArgs e)
        {
            SyncValues();
        }
        private void _xNum_ValueChanged(object sender, NumericUpDownValueChangedEventArgs e)
        {
            SyncValues();
        }
    }
}
