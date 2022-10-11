using System;
using System.Windows;
using System.Windows.Controls;

namespace ASO.Markdown.Controls;
public class AsoMarkdownDocumentEditor : Control
{
    public string Markdown
    {
        get
        {
            return _asoMarkdownEditor.Text;
        }
    }

    private AsoMarkdownEditor _asoMarkdownEditor;
    private AsoMarkdownEditor AsoMarkdownEditor
    {
        get
        {
            return _asoMarkdownEditor;
        }

        set
        {
            if (_asoMarkdownEditor != null)
            {
                _asoMarkdownEditor.TextChanged -=
                    new EventHandler(AsoMarkdownEditor_TextChanged);
            }
            _asoMarkdownEditor = value;

            if (_asoMarkdownEditor != null)
            {
                _asoMarkdownEditor.TextChanged +=
                    new EventHandler(AsoMarkdownEditor_TextChanged);
            }
        }
    }

    private AsoMarkdownViewer? _novaMarkdownViewer;
    
    private AsoMarkdownWebViewer? _webMarkdownViewer;


    static AsoMarkdownDocumentEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoMarkdownDocumentEditor), new FrameworkPropertyMetadata(typeof(AsoMarkdownDocumentEditor)));
    }

    private void AsoMarkdownEditor_TextChanged(object sender, EventArgs e)
    {
        if (_novaMarkdownViewer != null) _novaMarkdownViewer.Markdown = AsoMarkdownEditor.Text;
        if (_webMarkdownViewer != null) _webMarkdownViewer.Markdown = AsoMarkdownEditor.Text;
    }

    public override void OnApplyTemplate()
    {
        var exeption = new Exception($"Ошибка {OnApplyTemplate}");

        AsoMarkdownEditor = GetTemplateChild("Editor") as AsoMarkdownEditor ?? throw exeption;
        _novaMarkdownViewer = GetTemplateChild("AsoViewer") as AsoMarkdownViewer ?? throw exeption;
        _webMarkdownViewer = GetTemplateChild("WebViewer") as AsoMarkdownWebViewer ?? throw exeption;
    }
}
