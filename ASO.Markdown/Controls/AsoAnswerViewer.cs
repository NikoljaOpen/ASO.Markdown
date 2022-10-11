using ASO.Markdown.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ASO.Markdown.Controls;
public class AsoAnswerViewer : Control
{
    public Answer answer { get; set; } = new Answer();
    
    private Button _deleteButton;
    private Button DeleteButton
    {
        get
        {
            return _deleteButton;
        }

        set
        {
            if (_deleteButton != null)
            {
                _deleteButton.Click -=
                    new RoutedEventHandler(Click);
            }
            _deleteButton = value;

            if (_deleteButton != null)
            {
                _deleteButton.Click +=
                    new RoutedEventHandler(Click);
            }
        }
    }


    static AsoAnswerViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoAnswerViewer), new FrameworkPropertyMetadata(typeof(AsoAnswerViewer)));
    }

    private void Click(object sender, EventArgs e)
    {
        ((StackPanel)Parent).Children.Remove(this);
    }

    public override void OnApplyTemplate()
    {
        DeleteButton = GetTemplateChild("DeleteButton") as Button ?? throw new Exception($"Ошибка {OnApplyTemplate}");
    }
}
