using ASO.Markdown.Extensions;
using Markdig;
using Neo.Markdig.Xaml;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace ASO.Markdown.Controls;
public partial class AsoMarkdownViewer : UserControl
{
    private string _markdown = string.Empty;
    public string Markdown
    {
        get { return _markdown; }
        set
        {
            _markdown = value;
            RefreshDocument();
        }
    }

    private MarkdownPipeline _markdownPipeline =
        new MarkdownPipelineBuilder()
        .UseXamlSupportedExtensions()
        .Build();
    public MarkdownPipeline MarkdownPipeline
    {
        get { return _markdownPipeline; }
        set { _markdownPipeline = value; }
    }


    public AsoMarkdownViewer()
    {
        InitializeComponent();
    }

    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        var uri = e.Parameter as Uri;

        if (uri != null && uri.OriginalString != "#")
        {
            var uriFileInfo= new UriFileInfo(uri.AbsoluteUri);

            Process.Start("cmd", $"/c start {uriFileInfo.Uri}");
        }
    }

    public void RefreshDocument()
    {
        var document = MarkdownXaml.ToFlowDocument(Markdown, MarkdownPipeline);
        Viewer.Document = document;
    }
}
