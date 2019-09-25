using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CQDebuger.Control
{
    /// <summary>
    /// TextBoxWithLabel.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxWithLabel : UserControl
    {
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

        public TextBoxWithLabel()
        {
            InitializeComponent();
        }
    }
}
