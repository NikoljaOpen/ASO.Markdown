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
using System.Windows.Shapes;

namespace ASO.MarkdownTesting
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        string QuestionText;
        List<Answer> Answers;
        public QuestionWindow(string questionText,List<Answer> answers)
        {
            InitializeComponent();
            QuestionText = questionText;
            Answers = answers;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionTextView.Markdown = QuestionText;
            AnswerList.ItemsSource = Answers;
            AnswerList.Items.Refresh();
        }
    }
}
