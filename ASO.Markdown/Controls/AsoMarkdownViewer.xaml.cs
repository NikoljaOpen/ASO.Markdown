using Markdig;
using Markdig.Wpf;
using Neo.Markdig.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASO.Markdown.Controls
{

    public partial class AsoMarkdownViewer : UserControl
    {

        private string? markdown = string.Empty;
        public string? Markdown
        {
            get { return markdown; }
            set
            {
                var doc = MarkdownXaml.ToFlowDocument(
                            value,
                            new MarkdownPipelineBuilder()
                            .UseXamlSupportedExtensions()
                            .Build()
                );
                ScrollViewer.Document = doc;

                markdown = value;
            }
        }

        public AsoMarkdownViewer()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Parameter}") { CreateNoWindow = true });
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
    }
}
