using ASO.Markdown.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ASO.Markdown.Controls;
public class AsoAnswerEditor : Control
{
    public List<Answer> Answers
    {
        get
        {
            List<Answer> answerList = new List<Answer>();
            for(int i = 0; i < AnswersListView.Children.Count-1; i++)
            {
                answerList.Add(((AsoAnswerViewer)AnswersListView.Children[i]).answer);
                
            }
            return answerList;
        }
    }

    private StackPanel _answersListView;
    private StackPanel AnswersListView
    {
        get
        {
            return _answersListView;
        }

        set
        {
            _answersListView = value;
        }
    }


    public AsoAnswerEditor()
    {
        
    }

    static AsoAnswerEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoAnswerEditor), new FrameworkPropertyMetadata(typeof(AsoAnswerEditor)));
    }


    public override void OnApplyTemplate()
    {
        AnswersListView = GetTemplateChild("AnswersListView") as StackPanel ?? throw new Exception($"Ошибка {OnApplyTemplate}");
        AnswersListView.Children.Add(new AsoAnswerViewer());
        Button newAnswerBt = new Button()
        {
            Content = "+",
            Margin = new Thickness(5, 10, 5, 10),
            HorizontalAlignment = HorizontalAlignment.Left,
            Width = 30,
        };
        newAnswerBt.Click += NewAnswerBt_Click;
        AnswersListView.Children.Add(newAnswerBt);
    }

    private void NewAnswerBt_Click(object sender, RoutedEventArgs e)
    {
        if (AnswersListView.Children.Count > 1)
            AnswersListView.Children.Insert(AnswersListView.Children.Count - 1, new AsoAnswerViewer());
        else AnswersListView.Children.Insert(0, new AsoAnswerViewer());
    }

    private void AddAnswer(object sender, EventArgs e)
    {
        AnswersListView.Children.Insert(AnswersListView.Children.Count - 2, new AsoAnswerViewer());
    }
}
