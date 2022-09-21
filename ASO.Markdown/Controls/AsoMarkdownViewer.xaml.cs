﻿using Markdig;
using Markdig.Wpf;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ASO.Markdown;

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


    public AsoMarkdownViewer()
    {
        InitializeComponent();

        Viewer.Pipeline = new MarkdownPipelineBuilder()
            .UseSupportedExtensions()
            .UseBootstrap()
            .UseMediaLinks()
            .UseEmojiAndSmiley()
            .Build();
    }

    private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
        MessageBox.Show($"URL: {e.Parameter}");
        //Process.Start(e.Parameter.ToString());
    }

    private void ClickOnImage(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
        MessageBox.Show($"URL: {e.Parameter}");
    }
}

