using Markdig;
using System.IO;
using System.Windows.Controls;

namespace ASO.Markdown.Controls;
public partial class AsoMarkdownWebViewer : UserControl
{
    private string _path = string.Empty;
    public string Path
    {
        get { return _path; }
        set
        {
            _path = value;
            Markdown = File.ReadAllText(_path);
        }
    }

    private MarkdownPipeline _pipeline = new MarkdownPipelineBuilder()
        .UseSelfPipeline()
        .Build();
    public MarkdownPipeline Pipeline
    {
        get { return _pipeline; }
        set { _pipeline = value; }
    }

    private string _markdown;
    public string Markdown
    {
        get { return _markdown; }
        set
        {
            _markdown = value;
            DocumentUpdate();
        }
    }

    private bool EnsureCore = false;


    public AsoMarkdownWebViewer()
    {
        InitializeComponent();
    }

    private async void DocumentUpdate()
    {
        if (!EnsureCore)
        {
            await Viewer.EnsureCoreWebView2Async();
        }
        
        var html = Markdig.Markdown.ToHtml(Markdown, Pipeline);
        Viewer.NavigateToString(html);
    }
}

