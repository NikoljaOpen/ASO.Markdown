using ASO.Markdown.DialogWindows;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ASO.Markdown
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ASO.Markdown"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ASO.Markdown;assembly=ASO.Markdown"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:asoTextEditor/>
    ///
    /// </summary>
    public class asoMarkdownEditor : TextEditor
    {
        static asoMarkdownEditor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(asoMarkdownEditor), new FrameworkPropertyMetadata(typeof(asoMarkdownEditor)));
        }

        private MenuItem openFileItem;

        private MenuItem OpenFileItem
        {
            get
            {
                return openFileItem;
            }

            set
            {
                if (openFileItem != null)
                {
                    openFileItem.Click -=
                        new RoutedEventHandler(openFileItem_Click);
                }
                openFileItem = value;

                if (openFileItem != null)
                {
                    openFileItem.Click +=
                        new RoutedEventHandler(openFileItem_Click);
                }
            }
        }

        private MenuItem addImageItem;

        private MenuItem AddImageItem
        {
            get
            {
                return addImageItem;
            }

            set
            {
                if (addImageItem != null)
                {
                    addImageItem.Click -=
                        new RoutedEventHandler(addImageItem_Click);
                }
                addImageItem = value;

                if (addImageItem != null)
                {
                    addImageItem.Click +=
                        new RoutedEventHandler(addImageItem_Click);
                }
            }
        }

        private MenuItem addLinkItem;

        private MenuItem AddLinkItem
        {
            get
            {
                return addLinkItem;
            }

            set
            {
                if (addLinkItem != null)
                {
                    addLinkItem.Click -=
                        new RoutedEventHandler(addLinkItem_Click);
                }
                addLinkItem = value;

                if (addLinkItem != null)
                {
                    addLinkItem.Click +=
                        new RoutedEventHandler(addLinkItem_Click);
                }
            }
        }

        private MenuItem addTableItem;

        private MenuItem AddTableItem
        {
            get
            {
                return addTableItem;
            }

            set
            {
                if (addTableItem != null)
                {
                    addTableItem.Click -=
                        new RoutedEventHandler(addTableItem_Click);
                }
                addTableItem = value;

                if (addTableItem != null)
                {
                    addTableItem.Click +=
                        new RoutedEventHandler(addTableItem_Click);
                }
            }
        }

        private MenuItem boldItem;

        private MenuItem BoldItem
        {
            get
            {
                return boldItem;
            }

            set
            {
                if (boldItem != null)
                {
                    boldItem.Click -=
                        new RoutedEventHandler(boldItem_Click);
                }
                boldItem = value;

                if (boldItem != null)
                {
                    boldItem.Click +=
                        new RoutedEventHandler(boldItem_Click);
                }
            }
        }

        private MenuItem italicItem;

        private MenuItem ItalicItem
        {
            get
            {
                return italicItem;
            }

            set
            {
                if (italicItem != null)
                {
                    italicItem.Click -=
                        new RoutedEventHandler(italicItem_Click);
                }
                italicItem = value;

                if (italicItem != null)
                {
                    italicItem.Click +=
                        new RoutedEventHandler(italicItem_Click);
                }
            }
        }

        private MenuItem strikethroughItem;

        private MenuItem StrikethroughItem
        {
            get
            {
                return strikethroughItem;
            }

            set
            {
                if (strikethroughItem != null)
                {
                    strikethroughItem.Click -=
                        new RoutedEventHandler(strikethroughItem_Click);
                }
                strikethroughItem = value;

                if (strikethroughItem != null)
                {
                    strikethroughItem.Click +=
                        new RoutedEventHandler(strikethroughItem_Click);
                }
            }
        }

        private MenuItem underlineItem;

        private MenuItem UnderlineItem
        {
            get
            {
                return underlineItem;
            }

            set
            {
                if (underlineItem != null)
                {
                    underlineItem.Click -=
                        new RoutedEventHandler(underlineItem_Click);
                }
                underlineItem = value;

                if (underlineItem != null)
                {
                    underlineItem.Click +=
                        new RoutedEventHandler(underlineItem_Click);
                }
            }
        }

        private MenuItem saveFileItemItem;

        private MenuItem SaveFileItem
        {
            get
            {
                return saveFileItemItem;
            }

            set
            {
                if (saveFileItemItem != null)
                {
                    saveFileItemItem.Click -=
                        new RoutedEventHandler(saveFileItemItem_Click);
                }
                saveFileItemItem = value;

                if (saveFileItemItem != null)
                {
                    saveFileItemItem.Click +=
                        new RoutedEventHandler(saveFileItemItem_Click);
                }
            }
        }

        private MenuItem codeBlockItem;

        private MenuItem CodeBlockItem
        {
            get
            {
                return codeBlockItem;
            }

            set
            {
                if (codeBlockItem != null)
                {
                    codeBlockItem.Click -=
                        new RoutedEventHandler(codeBlockItem_Click);
                }
                codeBlockItem = value;

                if (codeBlockItem != null)
                {
                    codeBlockItem.Click +=
                        new RoutedEventHandler(codeBlockItem_Click);
                }
            }
        }

        private MenuItem literalListItem;

        private MenuItem LiteralListItem
        {
            get
            {
                return literalListItem;
            }

            set
            {
                if (literalListItem != null)
                {
                    literalListItem.Click -=
                        new RoutedEventHandler(literalListItem_Click);
                }
                literalListItem = value;

                if (literalListItem != null)
                {
                    literalListItem.Click +=
                        new RoutedEventHandler(literalListItem_Click);
                }
            }
        }

        private MenuItem bulletedListItem;

        private MenuItem BulletedListItem
        {
            get
            {
                return bulletedListItem;
            }

            set
            {
                if (bulletedListItem != null)
                {
                    bulletedListItem.Click -=
                        new RoutedEventHandler(bulletedListItem_Click);
                }
                bulletedListItem = value;

                if (bulletedListItem != null)
                {
                    bulletedListItem.Click +=
                        new RoutedEventHandler(bulletedListItem_Click);
                }
            }
        }

        private MenuItem numberedListItem;

        private MenuItem NumberedListItem
        {
            get
            {
                return numberedListItem;
            }

            set
            {
                if (numberedListItem != null)
                {
                    numberedListItem.Click -=
                        new RoutedEventHandler(numberedListItem_Click);
                }
                numberedListItem = value;

                if (numberedListItem != null)
                {
                    numberedListItem.Click +=
                        new RoutedEventHandler(numberedListItem_Click);
                }
            }
        }

        private MenuItem redoItem;

        private MenuItem RedoItem
        {
            get
            {
                return redoItem;
            }

            set
            {
                if (redoItem != null)
                {
                    redoItem.Click -=
                        new RoutedEventHandler(redoItem_Click);
                }
                redoItem = value;

                if (redoItem != null)
                {
                    redoItem.Click +=
                        new RoutedEventHandler(redoItem_Click);
                }
            }
        }

        private MenuItem undoItem;

        private MenuItem UndoItem
        {
            get
            {
                return undoItem;
            }

            set
            {
                if (undoItem != null)
                {
                    undoItem.Click -=
                        new RoutedEventHandler(undoItem_Click);
                }
                undoItem = value;

                if (undoItem != null)
                {
                    undoItem.Click +=
                        new RoutedEventHandler(undoItem_Click);
                }
            }
        }

        private MenuItem quoteItem;

        private MenuItem QuoteItem
        {
            get
            {
                return quoteItem;
            }

            set
            {
                if (quoteItem != null)
                {
                    quoteItem.Click -=
                        new RoutedEventHandler(quoteItem_Click);
                }
                quoteItem = value;

                if (quoteItem != null)
                {
                    quoteItem.Click +=
                        new RoutedEventHandler(quoteItem_Click);
                }
            }
        }

        private MenuItem helpItem;

        private MenuItem HelpItem
        {
            get
            {
                return helpItem;
            }

            set
            {
                if (helpItem != null)
                {
                    helpItem.Click -=
                        new RoutedEventHandler(helpItem_Click);
                }
                helpItem = value;

                if (helpItem != null)
                {
                    helpItem.Click +=
                        new RoutedEventHandler(helpItem_Click);
                }
            }
        }

        public override void OnApplyTemplate()
        {
            OpenFileItem = GetTemplateChild("OpenFileItem") as MenuItem;
            AddImageItem = GetTemplateChild("AddImageItem") as MenuItem;
            AddLinkItem = GetTemplateChild("AddLinkItem") as MenuItem;
            AddTableItem = GetTemplateChild("AddTableItem") as MenuItem;
            BoldItem = GetTemplateChild("BoldItem") as MenuItem;
            ItalicItem = GetTemplateChild("ItalicItem") as MenuItem;
            StrikethroughItem = GetTemplateChild("StrikethroughItem") as MenuItem;
            UnderlineItem = GetTemplateChild("UnderlineItem") as MenuItem;
            SaveFileItem = GetTemplateChild("SaveFileItem") as MenuItem;
            CodeBlockItem = GetTemplateChild("CodeBlockItem") as MenuItem;
            LiteralListItem = GetTemplateChild("LiteralListItem") as MenuItem;
            BulletedListItem = GetTemplateChild("BulletedListItem") as MenuItem;
            NumberedListItem = GetTemplateChild("NumberedListItem") as MenuItem;
            QuoteItem = GetTemplateChild("QuoteItem") as MenuItem;
            RedoItem = GetTemplateChild("RedoItem") as MenuItem;
            UndoItem = GetTemplateChild("UndoItem") as MenuItem;
            HelpItem = GetTemplateChild("HelpItem") as MenuItem;
        }

        public void openFileItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы Markdown  (*.md)|*.md";
            if (openFileDialog.ShowDialog() == true)
                this.Text = File.ReadAllText(openFileDialog.FileName);
        }

        public void saveFileItemItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы Markdown  (*.md)|*.md";
            if(saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                File.WriteAllText(filename, this.Text);
            }
        }

        public void addImageItem_Click(object sender, RoutedEventArgs e)
        {
            InputTextDialog inputTextDialog = new InputTextDialog("Введите ссылку", "добавить", "отменить");
            if (inputTextDialog.ShowDialog() == true)
            {
                Text = Text.Insert(SelectionStart, $"![]({inputTextDialog.Text})");
            }
        }

        public void addLinkItem_Click(object sender, RoutedEventArgs e)
        {
            InputTextDialog inputTextDialog = new InputTextDialog("Введите ссылку на изображение", "добавить", "отменить");
            if (inputTextDialog.ShowDialog() == true)
            {
                Text = Text.Insert(SelectionStart, $"[]({inputTextDialog.Text})");
            }
        }

        public void addTableItem_Click(object sender, RoutedEventArgs e)
        {
            InputTwoNumbersDialog inputTwoNumbersDialog = new InputTwoNumbersDialog("Введите кол-во колонок/строк таблицы", "добавить", "отменить");
            if (inputTwoNumbersDialog.ShowDialog() == true)
            {
                int a = inputTwoNumbersDialog.NumberOne;
                int b = inputTwoNumbersDialog.NumberTwo;
                string table = "";

                table += "\n|";
                for (int j = 0; j < a; j++)
                {
                    table += "  |";
                }
                table += "\n|";
                for (int j = 0; j < a; j++)
                {
                    table += "--|";
                }

                for (int i = 0; i < b - 1; i++)
                {
                    table += "\n|";
                    for (int j = 0; j < a; j++)
                    {
                        table += "  |";
                    }
                }

                Text = Text.Insert(SelectionStart, table);
            }
        }

        public void boldItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = $"**{SelectedText}**";
        }

        public void italicItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = $"*{SelectedText}*";
        }

        public void strikethroughItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = $"~~{SelectedText}~~";
        }

        public void underlineItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = $"++{SelectedText}++";
        }

        public void codeBlockItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = $"```\n{SelectedText}\n```";
        }

        public void literalListItem_Click(object sender, RoutedEventArgs e)
        {
            if(SelectionLength>0)
            SelectedText = "i. " + SelectedText.Replace("\n", "\ni. ");
            else
            {
                for(int i = SelectionStart-1; i >= 0; i--)
                {
                    if (Text[i] == '\n')
                    {
                        Text = Text.Insert(i+1, "i. ");
                        break;
                    }
                }
            }
        }

        public void numberedListItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = "1. " + SelectedText.Replace("\n", "\n1. ");
        }

        public void bulletedListItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = "* " + SelectedText.Replace("\n", "\n* ");

        }

        public void quoteItem_Click(object sender, RoutedEventArgs e)
        {
            SelectedText = ">" + SelectedText.Replace("\n", "\n>");
        }

        public void undoItem_Click(object sender, RoutedEventArgs e)
        {
            Undo();
        }

        public void redoItem_Click(object sender, RoutedEventArgs e)
        {
            Redo();
        }

        public void helpItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("help");
        }
    }
}
