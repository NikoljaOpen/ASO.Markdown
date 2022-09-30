using Markdig;
using System.IO;
using System.Windows.Controls;

namespace ASO.Markdown.Controls;

public partial class AsoMarkdownWebViewer : UserControl
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

    private MarkdownPipeline _Pipeline = new MarkdownPipelineBuilder()
        .UseSelfPipeline()
        .Build();
    public MarkdownPipeline Pipeline
    {
        get { return _Pipeline; }
        set { _Pipeline = value; }
    }

    private string? _Markdown;
    public string? Markdown
    {
        get { return _Markdown; }
        set
        {
            _Markdown = value;

            var html = Markdig.Markdown.ToHtml(_Markdown, _Pipeline);
            Viewer.NavigateToString(html);
        }
    }


    public AsoMarkdownWebViewer()
    {
        InitializeComponent();

        Viewer.EnsureCoreWebView2Async();
    }
}

