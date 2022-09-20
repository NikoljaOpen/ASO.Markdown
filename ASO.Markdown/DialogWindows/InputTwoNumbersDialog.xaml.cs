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
using System.Windows.Shapes;

namespace ASO.Markdown.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для InputTwoNumbersDialog.xaml
    /// </summary>
    public partial class InputTwoNumbersDialog : Window
    {
        public InputTwoNumbersDialog(string title, string okText, string cancelText)
        {
            InitializeComponent();
            Title = title;
            Ok.Content = okText;
            Cancel.Content = cancelText;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public int NumberOne
        {
            get { return int.Parse(NumberOneBox.Text); }
        }

        public int NumberTwo
        {
            get { return int.Parse(NumberTwoBox.Text); }
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsNumber(c))
                e.Handled = false;
            else
                e.Handled = true;

            base.OnPreviewTextInput(e);
        }
    }
}
