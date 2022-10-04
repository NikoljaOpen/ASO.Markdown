using System.Diagnostics;
using System.IO;
using System.Windows;
using ASO.Markdown;
using Markdig;
using Markdig.Wpf;

namespace ASO.MarkdownTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Viewer.Markdown = File.ReadAllText(@"C:\Users\nikol\Downloads\Пример.md");
        }
    }
}
