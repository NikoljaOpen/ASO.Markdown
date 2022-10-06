using ASO.Markdown.Extensions;
using Markdig;
using Neo.Markdig.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace ASO.Markdown.Controls;

public partial class NovaMarkdownViewer : UserControl
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


    public NovaMarkdownViewer()
    {
        InitializeComponent();
    }

    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        var par = (e.Parameter as Uri)?.AbsoluteUri ?? string.Empty;

        if (par != string.Empty)
            Process.Start("cmd", $"/c start {par}");
    }

    public void RefreshDocument()
    {
        var document = MarkdownXaml.ToFlowDocument(Markdown, MarkdownPipeline);
        Viewer.Document = document;
    }
}
