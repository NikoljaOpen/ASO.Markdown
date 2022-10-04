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
    /// Логика взаимодействия для AddLinkDialog.xaml
    /// </summary>
    public partial class AddLinkDialog : Window
    {
        public string LinkUrl
        {
            get
            {
                return LinkUrlBox.Text;
            }
        }

        public string LinkText
        {
            get
            {
                return LinkTextBox.Text;
            }
        }

        public AddLinkDialog()
        {
            InitializeComponent();
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
    }
}
