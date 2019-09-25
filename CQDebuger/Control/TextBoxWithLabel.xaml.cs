using System.Windows.Controls;

namespace CQDebuger.Control
{
    /// <summary>
    ///     TextBoxWithLabel.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxWithLabel : UserControl
    {
        public TextBoxWithLabel()
        {
            InitializeComponent();
        }

        public string TextBoxName
        {
            get => (string) NameLabel.Content;
            set => NameLabel.Content = value;
        }

        public string TextBoxText
        {
            get => InputTextBox.Text;
            set => InputTextBox.Text = value;
        }
    }
}