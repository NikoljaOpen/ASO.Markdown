using ASO.Markdown.MarkdownServise;
using Markdig;
using Markdig.Wpf;
using Neo.Markdig.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASO.Markdown.Controls
{
    public partial class AsoMarkdownViewer : UserControl
    {

        private string? _markdown = string.Empty;
        public string? Markdown
        {
            get { return _markdown; }
            set
            {
                _markdown = LinkConverter.ConvertLinksToAbsolute(value);

                var doc = MarkdownXaml.ToFlowDocument(
                            _markdown,
                            new MarkdownPipelineBuilder()
                            .UseXamlSupportedExtensions()
                            .UseEmojiAndSmiley()
                            .Build()
                );



                ScrollViewer.Document = doc;

                
            }
        }

        public static IEnumerable<DependencyObject> GetVisuals(DependencyObject root)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
            {
                yield return child;
                foreach (var descendants in GetVisuals(child))
                    yield return descendants;
            }
        }

        public AsoMarkdownViewer()
        {
            InitializeComponent();
        }
    }
}
