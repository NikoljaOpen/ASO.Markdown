using ASO.Markdown.DialogWindows;
using ICSharpCode.AvalonEdit;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ASO.Markdown.Controls;

public class AsoMarkdownEditor : TextEditor
{
    public Brush MenuBackground { get; set; }
    
    public Thickness MenuBorderThickness { get; set; }

    private MenuItem _openFileItem;
    private MenuItem OpenFileItem
    {
        get
        {
            return _openFileItem;
        }

        set
        {
            if (_openFileItem != null)
            {
                _openFileItem.Click -=
                    new RoutedEventHandler(openFileItem_Click);
            }
            _openFileItem = value;

            if (_openFileItem != null)
            {
                _openFileItem.Click +=
                    new RoutedEventHandler(openFileItem_Click);
            }
        }
    }

    private MenuItem _addImageItem;
    private MenuItem AddImageItem
    {
        get
        {
            return _addImageItem;
        }

        set
        {
            if (_addImageItem != null)
            {
                _addImageItem.Click -=
                    new RoutedEventHandler(addImageItem_Click);
            }
            _addImageItem = value;

            if (_addImageItem != null)
            {
                _addImageItem.Click +=
                    new RoutedEventHandler(addImageItem_Click);
            }
        }
    }

    private MenuItem _addLinkItem;
    private MenuItem AddLinkItem
    {
        get
        {
            return _addLinkItem;
        }

        set
        {
            if (_addLinkItem != null)
            {
                _addLinkItem.Click -=
                    new RoutedEventHandler(addLinkItem_Click);
            }
            _addLinkItem = value;

            if (_addLinkItem != null)
            {
                _addLinkItem.Click +=
                    new RoutedEventHandler(addLinkItem_Click);
            }
        }
    }

    private MenuItem _addTableItem;
    private MenuItem AddTableItem
    {
        get
        {
            return _addTableItem;
        }

        set
        {
            if (_addTableItem != null)
            {
                _addTableItem.Click -=
                    new RoutedEventHandler(addTableItem_Click);
            }
            _addTableItem = value;

            if (_addTableItem != null)
            {
                _addTableItem.Click +=
                    new RoutedEventHandler(addTableItem_Click);
            }
        }
    }

    private MenuItem _boldItem;
    private MenuItem BoldItem
    {
        get
        {
            return _boldItem;
        }

        set
        {
            if (_boldItem != null)
            {
                _boldItem.Click -=
                    new RoutedEventHandler(boldItem_Click);
            }
            _boldItem = value;

            if (_boldItem != null)
            {
                _boldItem.Click +=
                    new RoutedEventHandler(boldItem_Click);
            }
        }
    }

    private MenuItem _italicItem;
    private MenuItem ItalicItem
    {
        get
        {
            return _italicItem;
        }

        set
        {
            if (_italicItem != null)
            {
                _italicItem.Click -=
                    new RoutedEventHandler(italicItem_Click);
            }
            _italicItem = value;

            if (_italicItem != null)
            {
                _italicItem.Click +=
                    new RoutedEventHandler(italicItem_Click);
            }
        }
    }

    private MenuItem _strikethroughItem;
    private MenuItem StrikethroughItem
    {
        get
        {
            return _strikethroughItem;
        }

        set
        {
            if (_strikethroughItem != null)
            {
                _strikethroughItem.Click -=
                    new RoutedEventHandler(strikethroughItem_Click);
            }
            _strikethroughItem = value;

            if (_strikethroughItem != null)
            {
                _strikethroughItem.Click +=
                    new RoutedEventHandler(strikethroughItem_Click);
            }
        }
    }

    private MenuItem _underlineItem;
    private MenuItem UnderlineItem
    {
        get
        {
            return _underlineItem;
        }

        set
        {
            if (_underlineItem != null)
            {
                _underlineItem.Click -=
                    new RoutedEventHandler(underlineItem_Click);
            }
            _underlineItem = value;

            if (_underlineItem != null)
            {
                _underlineItem.Click +=
                    new RoutedEventHandler(underlineItem_Click);
            }
        }
    }

    private MenuItem _saveFileItemItem;
    private MenuItem SaveFileItem
    {
        get
        {
            return _saveFileItemItem;
        }

        set
        {
            if (_saveFileItemItem != null)
            {
                _saveFileItemItem.Click -=
                    new RoutedEventHandler(saveFileItemItem_Click);
            }
            _saveFileItemItem = value;

            if (_saveFileItemItem != null)
            {
                _saveFileItemItem.Click +=
                    new RoutedEventHandler(saveFileItemItem_Click);
            }
        }
    }

    private MenuItem _codeBlockItem;
    private MenuItem CodeBlockItem
    {
        get
        {
            return _codeBlockItem;
        }

        set
        {
            if (_codeBlockItem != null)
            {
                _codeBlockItem.Click -=
                    new RoutedEventHandler(codeBlockItem_Click);
            }
            _codeBlockItem = value;

            if (_codeBlockItem != null)
            {
                _codeBlockItem.Click +=
                    new RoutedEventHandler(codeBlockItem_Click);
            }
        }
    }

    private MenuItem _headingItem;
    private MenuItem HeadingItem
    {
        get
        {
            return _headingItem;
        }

        set
        {
            if (_headingItem != null)
            {
                _headingItem.Click -=
                    new RoutedEventHandler(headingItem_Click);
            }
            _headingItem = value;

            if (_headingItem != null)
            {
                _headingItem.Click +=
                    new RoutedEventHandler(headingItem_Click);
            }
        }
    }

    private MenuItem _bulletedListItem;
    private MenuItem BulletedListItem
    {
        get
        {
            return _bulletedListItem;
        }

        set
        {
            if (_bulletedListItem != null)
            {
                _bulletedListItem.Click -=
                    new RoutedEventHandler(bulletedListItem_Click);
            }
            _bulletedListItem = value;

            if (_bulletedListItem != null)
            {
                _bulletedListItem.Click +=
                    new RoutedEventHandler(bulletedListItem_Click);
            }
        }
    }

    private MenuItem _numberedListItem;
    private MenuItem NumberedListItem
    {
        get
        {
            return _numberedListItem;
        }

        set
        {
            if (_numberedListItem != null)
            {
                _numberedListItem.Click -=
                    new RoutedEventHandler(numberedListItem_Click);
            }
            _numberedListItem = value;

            if (_numberedListItem != null)
            {
                _numberedListItem.Click +=
                    new RoutedEventHandler(numberedListItem_Click);
            }
        }
    }

    private MenuItem _redoItem;
    private MenuItem RedoItem
    {
        get
        {
            return _redoItem;
        }

        set
        {
            if (_redoItem != null)
            {
                _redoItem.Click -=
                    new RoutedEventHandler(redoItem_Click);
            }
            _redoItem = value;

            if (_redoItem != null)
            {
                _redoItem.Click +=
                    new RoutedEventHandler(redoItem_Click);
            }
        }
    }

    private MenuItem _undoItem;
    private MenuItem UndoItem
    {
        get
        {
            return _undoItem;
        }

        set
        {
            if (_undoItem != null)
            {
                _undoItem.Click -=
                    new RoutedEventHandler(undoItem_Click);
            }
            _undoItem = value;

            if (_undoItem != null)
            {
                _undoItem.Click +=
                    new RoutedEventHandler(undoItem_Click);
            }
        }
    }

    private MenuItem _quoteItem;
    private MenuItem QuoteItem
    {
        get
        {
            return _quoteItem;
        }

        set
        {
            if (_quoteItem != null)
            {
                _quoteItem.Click -=
                    new RoutedEventHandler(quoteItem_Click);
            }
            _quoteItem = value;

            if (_quoteItem != null)
            {
                _quoteItem.Click +=
                    new RoutedEventHandler(quoteItem_Click);
            }
        }
    }

    private MenuItem _helpItem;
    private MenuItem HelpItem
    {
        get
        {
            return _helpItem;
        }

        set
        {
            if (_helpItem != null)
            {
                _helpItem.Click -=
                    new RoutedEventHandler(helpItem_Click);
            }
            _helpItem = value;

            if (_helpItem != null)
            {
                _helpItem.Click +=
                    new RoutedEventHandler(helpItem_Click);
            }
        }
    }


    public AsoMarkdownEditor()
    {
        BrushConverter bc = new BrushConverter();
        MenuBackground = (Brush)bc.ConvertFrom("#F8F9FA");
    }

    static AsoMarkdownEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoMarkdownEditor), new FrameworkPropertyMetadata(typeof(AsoMarkdownEditor)));
    }

    public override void OnApplyTemplate()
    {
        var exception = new System.Exception($"Ошибка {OnApplyTemplate}");

        OpenFileItem = GetTemplateChild("OpenFileItem") as MenuItem ?? throw exception;
        AddImageItem = GetTemplateChild("AddImageItem") as MenuItem ?? throw exception;
        AddLinkItem = GetTemplateChild("AddLinkItem") as MenuItem ?? throw exception;
        AddTableItem = GetTemplateChild("AddTableItem") as MenuItem ?? throw exception;
        BoldItem = GetTemplateChild("BoldItem") as MenuItem ?? throw exception;
        ItalicItem = GetTemplateChild("ItalicItem") as MenuItem ?? throw exception;
        StrikethroughItem = GetTemplateChild("StrikethroughItem") as MenuItem ?? throw exception;
        UnderlineItem = GetTemplateChild("UnderlineItem") as MenuItem ?? throw exception;
        SaveFileItem = GetTemplateChild("SaveFileItem") as MenuItem ?? throw exception;
        CodeBlockItem = GetTemplateChild("CodeBlockItem") as MenuItem ?? throw exception;
        HeadingItem = GetTemplateChild("HeadingItem") as MenuItem ?? throw exception;
        BulletedListItem = GetTemplateChild("BulletedListItem") as MenuItem ?? throw exception;
        NumberedListItem = GetTemplateChild("NumberedListItem") as MenuItem ?? throw exception;
        QuoteItem = GetTemplateChild("QuoteItem") as MenuItem ?? throw exception;
        RedoItem = GetTemplateChild("RedoItem") as MenuItem ?? throw exception;
        UndoItem = GetTemplateChild("UndoItem") as MenuItem ?? throw exception;
        HelpItem = GetTemplateChild("HelpItem") as MenuItem ?? throw exception;
    }

    public void openFileItem_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Файлы Markdown  (*.md)|*.md";
        if (openFileDialog.ShowDialog() == true)
            Text = File.ReadAllText(openFileDialog.FileName);
    }

    public void saveFileItemItem_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Файлы Markdown  (*.md)|*.md";
        if (saveFileDialog.ShowDialog() == true)
        {
            string filename = saveFileDialog.FileName;
            File.WriteAllText(filename, Text);
        }
    }

    public void addImageItem_Click(object sender, RoutedEventArgs e)
    {
        InputTextDialog inputTextDialog = new InputTextDialog("Введите ссылку", "добавить", "отменить");
        if (inputTextDialog.ShowDialog() == true)
        {
            SelectedText = $"![]({inputTextDialog.Text})";
        }
    }

    public void addLinkItem_Click(object sender, RoutedEventArgs e)
    {
        InputTextDialog inputTextDialog = new InputTextDialog("Введите ссылку на изображение", "добавить", "отменить");
        if (inputTextDialog.ShowDialog() == true)
        {
            SelectedText = $"[]({inputTextDialog.Text})";
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
            SelectedText = table;
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

    public void headingItem_Click(object sender, RoutedEventArgs e)
    {
        int start = SelectionStart;
        if (start == 0)
        {
            SelectedText = $"# {SelectedText}";
        }
        else
        {
            for (int i = start - 1; i >= 0; i--)
            {
                if (Text[i] == '\n')
                {
                    SelectionStart = i + 1;
                    SelectedText = $"# {SelectedText}";
                    break;
                }
                else if (i == 0)
                {
                    SelectionStart = i;
                    SelectedText = $"# {SelectedText}";
                    break;
                }
            }
        }
        int length = SelectionLength;
        this.SelectionLength = 0;
        SelectionStart = length;
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
        MarkdownInfoWindow window = new MarkdownInfoWindow();
        window.Show();
    }
}
