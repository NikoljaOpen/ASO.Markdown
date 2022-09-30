using Markdig.Renderers.Wpf;
using Markdig.Renderers.Wpf.Extensions;
using Markdig.Renderers.Wpf.Inlines;

namespace ASO.Markdown.Extensions;

public class WpfRenderer : Markdig.Renderers.WpfRenderer
{
    public WpfRenderer() : base()
    {

    }

    /// <summary>
    /// Перегружаемый метод для возможности добавить новые рендеры для AsoMarkdownViewer
    /// </summary>
    protected override void LoadRenderers()
    {
        // Default block renderers
        ObjectRenderers.Add(new CodeBlockRenderer());
        ObjectRenderers.Add(new ListRenderer());
        ObjectRenderers.Add(new HeadingRenderer());
        ObjectRenderers.Add(new ParagraphRenderer());
        ObjectRenderers.Add(new QuoteBlockRenderer());
        ObjectRenderers.Add(new ThematicBreakRenderer());

        // Default inline renderers
        ObjectRenderers.Add(new AutolinkInlineRenderer());
        ObjectRenderers.Add(new CodeInlineRenderer());
        ObjectRenderers.Add(new DelimiterInlineRenderer());
        ObjectRenderers.Add(new EmphasisInlineRenderer());
        ObjectRenderers.Add(new HtmlEntityInlineRenderer());
        ObjectRenderers.Add(new LineBreakInlineRenderer());
        ObjectRenderers.Add(new ASO.Markdown.Extensions.LinkInlineRenderer());
        ObjectRenderers.Add(new LiteralInlineRenderer());

        // Extension renderers
        ObjectRenderers.Add(new TableRenderer());
        ObjectRenderers.Add(new TaskListRenderer());
    }
}
