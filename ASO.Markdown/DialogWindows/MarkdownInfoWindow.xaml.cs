using Markdig;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MarkdownInfoWindow.xaml
    /// </summary>
    public partial class MarkdownInfoWindow : Window
    {
        public MarkdownInfoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Viewer.Markdown = File.ReadAllText("MarkdownInfoFiles/home.md");
        }
    }
}
