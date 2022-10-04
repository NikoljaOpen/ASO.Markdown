using System.Diagnostics;
using System.IO;
using System.Windows;
using ASO.Markdown;
using ASO.Markdown.MarkdownServise;
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
            
        }

        private void AsoRichEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string mark = FlowDocumentToMarkdown.Parse(Editor.Document);
            Viewer.Markdown = mark;
        }
    }
}
