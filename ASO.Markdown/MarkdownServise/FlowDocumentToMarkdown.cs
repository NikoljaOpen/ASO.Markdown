using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace ASO.Markdown.MarkdownServise
{
    public static class FlowDocumentToMarkdown
    {
        public static string Parse(FlowDocument document)
        {
            return ParseBloks(document.Blocks,true);
        }

        public static string ParseBloks(BlockCollection blocks, bool wraping = false, int l = 0, string secton = "")
        {
            string text = "";
            string lbr = wraping ? $"{secton}\n{secton}\n" : "";
            string br = wraping ? $"\n{secton}\n" : "";
            foreach (Block block in blocks)
            {
                switch (block.GetType().Name)
                {
                    case "Paragraph":
                        Paragraph paragraph = (Paragraph)block;

                        switch (paragraph.FontSize)
                        {
                            case 42:
                                text += $"{lbr}{secton}# {ParseInlines(paragraph.Inlines, false)}{br}";
                                break;

                            case 20:
                                text += $"{lbr}{secton}## {ParseInlines(paragraph.Inlines, false)}{br}";
                                break;

                            case 18:

                                if (paragraph.FontWeight == FontWeights.Bold)
                                {
                                    text += $"{lbr}{secton}### {ParseInlines(paragraph.Inlines, false)}{br}";
                                }
                                else text += $"{lbr}{secton}#### {ParseInlines(paragraph.Inlines, false)}{br}";
                                break;

                            default:
                                if (paragraph.Background != null)
                                {
                                    text += $"\n\n```\n{ParseInlines(paragraph.Inlines, false)}\n```\n\n";
                                }
                                else if (paragraph.BorderThickness.Equals(new Thickness(0, 0, 0, 1)))
                                {
                                    text += $"\n\n{secton}---\n\n";
                                }
                                else text += $"{lbr}{secton}{ParseInlines(paragraph.Inlines, false)}{br}";
                                break;
                        }


                        break;

                    case "List":
                        List list = (List)block;
                        text += $"{ParseList(list, l)}";
                        break;

                    case "Section":
                        Section section = (Section)block;
                        text += $"{ParseBloks(section.Blocks, true, 0, ">")}{br}";
                        break;

                    case "Table":
                        Table table = (Table)block;
                        text += $"{ParseTable(table)}";
                        break;
                }
            }

            return text;
        }

        public static string ParseTable(Table table)
        {
            string text = "";
            int rowcount = 0;

            foreach (TableRowGroup rowGroup in table.RowGroups)
            {
                foreach (TableRow row in rowGroup.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        text += $"|{ParseBloks(cell.Blocks),-30}";
                    }
                    text += "|\n";
                    if (rowcount == 0)
                    {
                        foreach (TableCell cell in row.Cells)
                        {
                            if (cell.TextAlignment == TextAlignment.Center)
                            {
                                text += $"|:----------------------------:";
                            }
                            else if (cell.TextAlignment == TextAlignment.Left)
                            {
                                text += $"|:-----------------------------";
                            }
                            else if (cell.TextAlignment == TextAlignment.Right)
                            {
                                text += $"|-----------------------------:";
                            }
                            else text += $"|------------------------------";

                        }
                        text += "|\n";
                    }
                    rowcount++;
                }

            }

            return $"\n\n{text}\n\n";
        }

        public static string ParseList(List list, int l = 0)
        {
            string text = "";
            string marker = "";
            string margin = "";
            if (l > 0)
            {
                for (int i = 0; i < l; i++)
                {
                    margin += "  ";
                }
            }
            if (list.MarkerStyle == TextMarkerStyle.Decimal)
            {
                marker = "1. ";
            }
            else
            {
                marker = "* ";
            }
            l++;
            foreach (ListItem item in list.ListItems)
            {
                text += $"\n{margin}{marker}{ParseBloks(item.Blocks, false, l)}";
            }
            return text;
        }

        public static string ParseInlines(InlineCollection inlines, bool wraping)
        {
            string text = "";
            string br = wraping ? "\n" : "";
            foreach (Inline inline in inlines)
            {
                switch (inline.GetType().Name)
                {
                    case "Run":
                        Run run = ((Run)inline);
                        string currentString = run.Text;
                        if (run.FontWeight == FontWeights.Bold && run.FontSize == 12)
                        {
                            currentString = $"**{currentString}**";
                        }
                        if (run.FontStyle == FontStyles.Italic)
                        {
                            currentString = $"*{currentString}*";
                        }
                        if (run.TextDecorations.Equals(TextDecorations.Underline))
                        {
                            currentString = $"++{currentString}++";
                        }
                        if (run.TextDecorations.Equals(TextDecorations.Strikethrough))
                        {
                            currentString = $"~~{currentString}~~";
                        }
                        text += $"{br}{currentString}";

                        break;

                    case "Bold":
                        text += $"**{ParseInlines(((Bold)inline).Inlines, false)}**";
                        break;

                    case "Italic":
                        text += $"*{ParseInlines(((Italic)inline).Inlines, false)}*";
                        break;
                    case "Span":
                        Span span = ((Span)inline);
                        if (span.TextDecorations.Count != 0)
                        {
                            foreach (TextDecoration textDecoration in span.TextDecorations)
                            {
                                if (textDecoration.Location == TextDecorationLocation.Underline)
                                {
                                    text += $"++{ParseInlines(span.Inlines, false)}++";
                                }
                                else if (textDecoration.Location == TextDecorationLocation.Strikethrough)
                                {
                                    text += $"~~{ParseInlines(span.Inlines, false)}~~";
                                }
                                else
                                {
                                    text += $"{ParseInlines(span.Inlines, false)}";
                                }
                            }
                        }
                        else if (span.FontFamily.Equals(new FontFamily("Consolas, Lucida Sans Typewriter, Courier New")))
                        {
                            text += $"`{ParseInlines(span.Inlines, false)}`";
                        }
                        else
                        {
                            text += $"=={ParseInlines(span.Inlines, false)}==";
                        }
                        break;

                    case "Hyperlink":
                        Hyperlink link = ((Hyperlink)inline);
                        text += $"[{ParseInlines(link.Inlines, true)}]({link.NavigateUri})";
                        break;

                    case "InlineUIContainer":
                        InlineUIContainer inlineUIContainer = ((InlineUIContainer)inline);
                        Image image = (Image)inlineUIContainer.Child;
                        string url = "";
                        if (image.Source != null) url = image.Source.ToString();
                        text += $"![]({url})";
                        break;

                    case "LineBreak":
                        text += "  \n";
                        break;
                }
            }

            return text;
        }

    }
}
