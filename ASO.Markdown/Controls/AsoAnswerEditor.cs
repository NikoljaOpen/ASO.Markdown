using ASO.Markdown.Models;
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
        private StackPanel answersListView;
        private StackPanel AnswersListView
        {
            get
            {
                return answersListView;
            }

            set
            {
                answersListView = value;
            }
        }

        public override void OnApplyTemplate()
        {
            AnswersListView = GetTemplateChild("AnswersListView") as StackPanel;
            AnswersListView.Children.Add(new AsoAnswerViewer());
            Button newAnswerBt = new Button();
            newAnswerBt.Content = "+";
            newAnswerBt.Margin = new Thickness(5,10,5,10);
            newAnswerBt.HorizontalAlignment = HorizontalAlignment.Left;
            newAnswerBt.Width = 30;
            newAnswerBt.Click += NewAnswerBt_Click;
            AnswersListView.Children.Add(newAnswerBt);
        }

        private void NewAnswerBt_Click(object sender, RoutedEventArgs e)
        {
            if(AnswersListView.Children.Count>1)
            AnswersListView.Children.Insert(AnswersListView.Children.Count - 1, new AsoAnswerViewer());
            else AnswersListView.Children.Insert(0, new AsoAnswerViewer());
        }

        private void AddAnswer(object sender, EventArgs e)
        {
            AnswersListView.Children.Insert(AnswersListView.Children.Count - 2, new AsoAnswerViewer());
        }

        public AsoAnswerEditor()
        {
            
        }

        static AsoAnswerEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoAnswerEditor), new FrameworkPropertyMetadata(typeof(AsoAnswerEditor)));
        }
    }
}
