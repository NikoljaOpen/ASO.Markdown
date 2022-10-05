using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASO.Markdown.Controls
{
    public class AsoMarkdownDocumentEditor : Control
    {
        public string Markdown
        {
            get
            {
                return asoMarkdownEditor.Text;
            }
        }

        private AsoMarkdownEditor asoMarkdownEditor;

        private AsoMarkdownEditor AsoMarkdownEditor
        {
            get
            {
                return asoMarkdownEditor;
            }

            set
            {
                if (asoMarkdownEditor != null)
                {
                    asoMarkdownEditor.TextChanged -=
                        new EventHandler(asoMarkdownEditor_TextChanged);
                }
                asoMarkdownEditor = value;

                if (asoMarkdownEditor != null)
                {
                    asoMarkdownEditor.TextChanged +=
                        new EventHandler(asoMarkdownEditor_TextChanged);
                }
            }
        }

        private AsoMarkdownViewer AsoMarkdownViewer;
        private NovaMarkdownViewer NovaMarkdownViewer;
        private void asoMarkdownEditor_TextChanged(object sender, EventArgs e)
        {
            if (AsoMarkdownViewer != null) AsoMarkdownViewer.Markdown = AsoMarkdownEditor.Text;
            if (NovaMarkdownViewer != null) NovaMarkdownViewer.Markdown = AsoMarkdownEditor.Text;
        }

        public override void OnApplyTemplate()
        {
            AsoMarkdownEditor = GetTemplateChild("Editor") as AsoMarkdownEditor;
            AsoMarkdownViewer = GetTemplateChild("Viewer") as AsoMarkdownViewer;
            NovaMarkdownViewer = GetTemplateChild("NovaViewer") as NovaMarkdownViewer;
        }

        static AsoMarkdownDocumentEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoMarkdownDocumentEditor), new FrameworkPropertyMetadata(typeof(AsoMarkdownDocumentEditor)));
        }
    }
}
