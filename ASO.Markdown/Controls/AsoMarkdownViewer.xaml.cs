using ASO.Markdown.Extensions;
using Markdig;
using Markdig.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASO.Markdown.Controls;

public partial class AsoMarkdownViewer : UserControl
{
    private string? _markdown = string.Empty;
    public string? Markdown
    {
        get { return _markdown; }
        set
        {
            _markdown = value;
            Viewer.Markdown = _markdown;
        }
    }

    public MarkdownPipeline Pipeline
    {
        get { return Viewer.Pipeline; }
        set { Viewer.Pipeline = value; }
    }


    public AsoMarkdownViewer()
    {
        InitializeComponent();

        Viewer.Pipeline = new MarkdownPipelineBuilder()
            .UseSupportedExtensions()
            .UseAbbreviations()
            .UseAdvancedExtensions()
            .UseAutoIdentifiers()
            .UseAutoLinks()
            .UseBootstrap()
            .UseCitations()
            .UseCustomContainers()
            .UseDefinitionLists()
            .UseDiagrams()
            .UseEmojiAndSmiley()
            .UseEmphasisExtras()
            .UseFigures()
            .UseFooters()
            .UseFootnotes()
            .UseGenericAttributes()
            .UseGlobalization()
            .UseGridTables()
            .UseListExtras()
            .UseMathematics()
            .UseMediaLinks()
            .UseNonAsciiNoEscape()
            .UsePipeTables()
            .UsePragmaLines()
            .UsePreciseSourceLocation()
            .UseReferralLinks()
            .Build();
    }

    private void OpenLink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
        var par = e.Parameter as string ?? string.Empty;

        if (par != string.Empty)
            Process.Start("cmd", $"/c start {par}");
    }
}