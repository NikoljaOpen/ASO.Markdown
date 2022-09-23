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
    public class AsoAnswerViewer : Control
    {
        public Answer answer { get; set; } = new Answer();
        private Button deleteButton;

        private Button DeleteButton
        {
            get
            {
                return deleteButton;
            }

            set
            {
                if (deleteButton != null)
                {
                    deleteButton.Click -=
                        new RoutedEventHandler(Click);
                }
                deleteButton = value;

                if (deleteButton != null)
                {
                    deleteButton.Click +=
                        new RoutedEventHandler(Click);
                }
            }
        }

        private void Click(object sender, EventArgs e)
        {
            ((StackPanel)Parent).Children.Remove(this);
            
        }

        public override void OnApplyTemplate()
        {
            DeleteButton = GetTemplateChild("DeleteButton") as Button;
        }

        static AsoAnswerViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoAnswerViewer), new FrameworkPropertyMetadata(typeof(AsoAnswerViewer)));
        }
    }
}
