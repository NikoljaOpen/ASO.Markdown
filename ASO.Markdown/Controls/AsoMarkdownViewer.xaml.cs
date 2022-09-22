using Markdig;
using Markdig.Wpf;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ASO.Markdown.Controls;

public partial class AsoMarkdownViewer : UserControl
{
    private string _Path = string.Empty;
    public string Path
    {
        get { return _Path; }
        set
        {
            _Path = value;
            Markdown = File.ReadAllText(_Path);
        }
    }

    private string? _Markdown = string.Empty;
    public string? Markdown
    {
        get { return _Markdown; }
        set
        {
            _Markdown = value;
            Viewer.Markdown = _Markdown;
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

    private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
        Process.Start("cmd", $"/c start {e.Parameter}");
    }

    private void ClickOnImage(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
        MessageBox.Show($"URL: {e.Parameter}");
    }
}