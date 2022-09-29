namespace ASO.Markdown.Extensions;

public class MarkdownViewer : Markdig.Wpf.MarkdownViewer
{
    protected override void RefreshDocument()
    {
        Document = Markdown != null ? Markdig.Wpf.Markdown.ToFlowDocument(Markdown, Pipeline ?? DefaultPipeline, new ASO.Markdown.Extensions.WpfRenderer()) : null;
    }
}
