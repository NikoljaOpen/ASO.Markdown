using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
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

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Parameter}") { CreateNoWindow = true });
            /*
             * http запрос, узнать что за содержание вернет видео или фильм
             */
        }

        private void AsoRichEditor_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string mark = FlowDocumentToMarkdown.Parse(Editor.Document);
            Viewer.Markdown = mark;
        }
    }
}
