using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using ASO.Markdown;
using ASO.Markdown.Controls;
using Markdig;
using Markdig.Wpf;
using Microsoft.Web.WebView2.Core;

namespace ASO.MarkdownTesting
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start("cmd", $"/c start {e.Uri}");
        }
    }
}
