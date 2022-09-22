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

        private void Editor_TextChanged(object sender, System.EventArgs e)
        {
            Viewer.Markdown = Editor.Text;
        }
    }
}
