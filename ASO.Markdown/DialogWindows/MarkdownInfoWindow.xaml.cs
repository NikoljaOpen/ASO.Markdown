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
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseEmojiAndSmiley().UseMediaLinks().Build();
            string markdown = File.ReadAllText("MarkdownInfoFiles/home.md");
            string style = "<style>\r\n" +
            "table, th, td {\r\n" +
            "  border: 1px solid;\r\n" +
            "  border-color:silver;\r\n" +
            "  padding:10px;\r\n}\r\n" +
            "th {" +
            "\r\n\tbackground-color:#E5E8E8;\r\n}" +
            "\r\ntable {" +
            "\r\n  border-collapse: collapse;\r\n}\r\n" +
            "tr:nth-child(even) {\r\n" +
            "  background-color: #f1f1f1;\r\n}\r\n\r\n" +
            "blockquote {" +
            "\r\n\tmargin:0;\r\n" +
            "    padding-left: 1em;\r\n" +
            "    border-left: 0.2em solid #57606a;\r\n" +
            "    color: #57606a;\r\n}\r\n" +
            "h1, h2, h3, h4 {" +
            "\r\n\tborder-bottom:0.04em solid #E5E8E8;" +
            "\r\n\tmargin:24px 0 16px 0;\r\n}\r\n" +
            "body {" +
            "\r\n\tmargin:1em;\r\n" +
            "    color:#24292F;\r\n" +
            "    font-family: -apple-system,BlinkMacSystemFont,\"Segoe UI\",Helvetica,Arial,sans-serif,\"Apple Color Emoji\",\"Segoe UI Emoji\";\r\n" +
            "    font-size:16px;\r\n}\r\n" +
            "pre {" +
            "\r\n\t\r\n" +
            "    padding:0.8em;\r\n" +
            "    border-radius:0.5em;\r\n" +
            "    overflow: auto;\r\n}\r\n" +
            "a {" +
            "\r\n\tcolor:#0969da;\r\n}\r\n" +
            "img {" +
            "\r\n\tmax-width:95%;\r\n}\r\n" +
            "</style>";
            Browser.NavigateToString($"<meta http-equiv=\"X-UA-Compatible\" content=\"IE=11\"/><meta charset=\"UTF-8\">{style}{Markdig.Markdown.ToHtml(markdown, pipeline)}");
        }
    }
}
