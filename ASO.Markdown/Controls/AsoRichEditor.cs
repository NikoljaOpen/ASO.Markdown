using ASO.Markdown.DialogWindows;
using ASO.Markdown.MarkdownServise;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ASO.Markdown.Controls;
public class AsoRichEditor : RichTextBox
{
    int CurrentBlocsCount;
    FontFamily DefaultFont = new FontFamily("Segoe UI");

    static AsoRichEditor()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AsoRichEditor), new FrameworkPropertyMetadata(typeof(AsoRichEditor)));
        
    }

    public AsoRichEditor()
    {
        DataObject.AddPastingHandler(this, new DataObjectPastingEventHandler(MyPasteCommand));
        TextChanged += AsoRichEditor_TextChanged;
        CurrentBlocsCount = Document.Blocks.Count;
    }

    private void RequestNavigated(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Uri}") { CreateNoWindow = true });
    }

    void MyPasteCommand(object sender, DataObjectPastingEventArgs e)
    {

        if (Clipboard.ContainsText() == true)
        {
            string clipboardText = (string)e.DataObject.GetData(DataFormats.Text);
            if (Selection.IsEmpty)
            {
                
                Run run = new Run(clipboardText, CaretPosition.GetInsertionPosition(LogicalDirection.Forward));
            }
            else
            {
                Selection.Text = clipboardText;
            }
            e.CancelCommand();
        }
        
        
    }

    #region MenuItems

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
            boldItem = value;
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
            italicItem = value;
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

    private MenuItem heading1Item;

    private MenuItem Heading1Item
    {
        get
        {
            return heading1Item;
        }

        set
        {
            if (heading1Item != null)
            {
                heading1Item.Click -=
                    new RoutedEventHandler(heading1Item_Click);
            }
            heading1Item = value;

            if (heading1Item != null)
            {
                heading1Item.Click +=
                    new RoutedEventHandler(heading1Item_Click);
            }
        }
    }

    private MenuItem heading2Item;

    private MenuItem Heading2Item
    {
        get
        {
            return heading2Item;
        }

        set
        {
            if (heading2Item != null)
            {
                heading2Item.Click -=
                    new RoutedEventHandler(heading2Item_Click);
            }
            heading2Item = value;

            if (heading2Item != null)
            {
                heading2Item.Click +=
                    new RoutedEventHandler(heading2Item_Click);
            }
        }
    }

    private MenuItem heading3Item;

    private MenuItem Heading3Item
    {
        get
        {
            return heading3Item;
        }

        set
        {
            if (heading3Item != null)
            {
                heading3Item.Click -=
                    new RoutedEventHandler(heading3Item_Click);
            }
            heading3Item = value;

            if (heading3Item != null)
            {
                heading3Item.Click +=
                    new RoutedEventHandler(heading3Item_Click);
            }
        }
    }

    private MenuItem heading4Item;

    private MenuItem Heading4Item
    {
        get
        {
            return heading4Item;
        }

        set
        {
            if (heading4Item != null)
            {
                heading4Item.Click -=
                    new RoutedEventHandler(heading4Item_Click);
            }
            heading4Item = value;

            if (heading4Item != null)
            {
                heading4Item.Click +=
                    new RoutedEventHandler(heading4Item_Click);
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
    #endregion

    #region MenuItemMethods

    private void AsoRichEditor_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (CurrentBlocsCount < Document.Blocks.Count)
        {
            ClearParagraphStyle();
        }
        CurrentBlocsCount = Document.Blocks.Count;
    }

    void ClearParagraphStyle()
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        paragraph.FontSize = 12;
        paragraph.FontWeight = FontWeights.Normal;
        paragraph.FontFamily = DefaultFont;
        paragraph.Background = null;
        paragraph.TextDecorations = null;
    }

    public void addImageItem_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;

        InputTextDialog inputTextDialog = new InputTextDialog("Введите ссылку на изображение", "добавить", "отменить");
        if (inputTextDialog.ShowDialog() == true)
        {
            
            Image image = new Image();
            BitmapSource bitmapSource = new BitmapImage(new Uri(LinkConverter.ConvertToAbsolute(inputTextDialog.Text)));
            image.Source = bitmapSource;
            
            Binding heightBinding = new Binding();
            heightBinding.Path = new PropertyPath("Source.(BitmapSource.PixelHeight)");
            heightBinding.RelativeSource = RelativeSource.Self;
            image.SetBinding(HeightProperty, heightBinding);

            Binding widthBinding = new Binding();
            widthBinding.Path = new PropertyPath("Source.(BitmapSource.PixelWidth)");
            widthBinding.RelativeSource = RelativeSource.Self;
            image.SetBinding(WidthProperty, widthBinding);
            
            new InlineUIContainer(image,CaretPosition.GetInsertionPosition(LogicalDirection.Forward));
        }
    }

    public void addLinkItem_Click(object sender, RoutedEventArgs e)
    {
        AddLinkDialog linkDialog = new AddLinkDialog();
        if (linkDialog.ShowDialog() == true)
        {
            Hyperlink hyperlink = new Hyperlink(CaretPosition.GetInsertionPosition(LogicalDirection.Forward), CaretPosition.GetInsertionPosition(LogicalDirection.Forward))
            {
                NavigateUri = new Uri(LinkConverter.ConvertToAbsolute(linkDialog.LinkUrl)),
            };
            if(linkDialog.LinkImage == null || linkDialog.LinkImage == "") hyperlink.Inlines.Add(new Run(linkDialog.LinkText));
            else
            {
                InlineUIContainer container = new InlineUIContainer();
                Image image = new Image();
                BitmapSource bitmapSource = new BitmapImage(new Uri(LinkConverter.ConvertToAbsolute(linkDialog.LinkImage)));
                image.Source = bitmapSource;

                Binding heightBinding = new Binding();
                heightBinding.Path = new PropertyPath("Source.(BitmapSource.PixelHeight)");
                heightBinding.RelativeSource = RelativeSource.Self;
                image.SetBinding(HeightProperty, heightBinding);

                Binding widthBinding = new Binding();
                widthBinding.Path = new PropertyPath("Source.(BitmapSource.PixelWidth)");
                widthBinding.RelativeSource = RelativeSource.Self;
                image.SetBinding(WidthProperty, widthBinding);

                container.Child = image;

                hyperlink.Inlines.Add(container);
            }
            hyperlink.RequestNavigate += RequestNavigated;
        }
    }

    public void addTableItem_Click(object sender, RoutedEventArgs e)
    {
        InputTwoNumbersDialog inputTwoNumbersDialog = new InputTwoNumbersDialog("Введите кол-во колонок/строк таблицы", "добавить", "отменить");
        if (inputTwoNumbersDialog.ShowDialog() == true)
        {
            int a = inputTwoNumbersDialog.NumberOne;
            int b = inputTwoNumbersDialog.NumberTwo;
            Table table = new Table();
            table.BorderBrush = Brushes.Black;
            table.BorderThickness = new Thickness(0, 0, 1, 1);
            TableRowGroup rowGroup = new TableRowGroup();

            for (int i = 0; i < b; i++)
            {
                TableRow row = new TableRow();
                row.Tag = i;
                rowGroup.Rows.Add(row);
                for (int j = 0; j < a; j++)
                {
                    TableCell cell = new TableCell();
                    cell.BorderThickness = new Thickness(1, 1, 0, 0);
                    cell.BorderBrush = Brushes.Black;
                    cell.Blocks.Add(new Paragraph());

                    ContextMenu contextMenu = new ContextMenu();

                    AddItemsToContextMenu(contextMenu, row, table, j);

                    cell.ContextMenu = contextMenu;

                    row.Cells.Add(cell);
                }
            }
            table.RowGroups.Add(rowGroup);
            Document.Blocks.InsertAfter(CaretPosition.Paragraph, table);
        }
    }

    private void AddRowDownMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        TableRow row = (TableRow)((MenuItem)sender).Tag;
        int index = (int)row.Tag;
        TableRow newRow = new TableRow();

        for (int j = 0; j < row.Cells.Count; j++)
        {
            TableCell cell = new TableCell();
            cell.BorderThickness = new Thickness(1, 1, 0, 0);
            cell.BorderBrush = Brushes.Black;
            cell.TextAlignment = row.Cells[j].TextAlignment;
            cell.Blocks.Add(new Paragraph());

            ContextMenu contextMenu = new ContextMenu();

            AddItemsToContextMenu(contextMenu, newRow, table, j);

            cell.ContextMenu = contextMenu;

            newRow.Cells.Add(cell);
        }
        table.RowGroups[0].Rows.Insert(index+1, newRow);

        for (int i = 0; i < table.RowGroups[0].Rows.Count; i++)
        {
            table.RowGroups[0].Rows[i].Tag = i;
        }
    }

    private void AddRowUpMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        TableRow row = (TableRow)((MenuItem)sender).Tag;
        int index = (int)row.Tag;
        TableRow newRow = new TableRow();

        for (int j = 0; j < row.Cells.Count; j++)
        {
            TableCell cell = new TableCell();
            cell.BorderThickness = new Thickness(1, 1, 0, 0);
            cell.BorderBrush = Brushes.Black;
            cell.TextAlignment = row.Cells[j].TextAlignment;
            cell.Blocks.Add(new Paragraph());

            ContextMenu contextMenu = new ContextMenu();

            AddItemsToContextMenu(contextMenu,newRow,table, j);

            cell.ContextMenu = contextMenu;

            newRow.Cells.Add(cell);
        }
        table.RowGroups[0].Rows.Insert(index, newRow);

        for (int i = 0; i < table.RowGroups[0].Rows.Count; i++)
        {
            table.RowGroups[0].Rows[i].Tag = i;
        }
    }

    private void DeleteRowMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        TableRow row = (TableRow)((MenuItem)sender).Tag;
        table.RowGroups[0].Rows.Remove(row);
        for(int i = 0; i < table.RowGroups[0].Rows.Count; i++)
        {
            table.RowGroups[0].Rows[i].Tag = i;
        }
    }

    private void DeleteColumnMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        int column = (int)((MenuItem)sender).Tag;
        foreach (TableRow row in table.RowGroups[0].Rows)
        {
            row.Cells.RemoveAt(column);
            for (int i = 0; i < row.Cells.Count; i++)
            {
                foreach (MenuItem item in row.Cells[i].ContextMenu.Items)
                {
                    if(item.Tag is int)item.Tag = i;
                }
            }
        }
    }

    private void AddItemsToContextMenu(ContextMenu contextMenu, TableRow row, Table table, int columnIndex = 0)
    {
        MenuItem centerMenuItem = new MenuItem();
        centerMenuItem.CommandParameter = table;
        centerMenuItem.Header = "По центу";
        centerMenuItem.Tag = columnIndex;
        centerMenuItem.Click += CenterMenuItem_Click;
        contextMenu.Items.Add(centerMenuItem);

        MenuItem leftMenuItem = new MenuItem();
        leftMenuItem.CommandParameter = table;
        leftMenuItem.Header = "По левой стороне";
        leftMenuItem.Tag = columnIndex;
        leftMenuItem.Click += LeftMenuItem_Click;
        contextMenu.Items.Add(leftMenuItem);

        MenuItem rightMenuItem = new MenuItem();
        rightMenuItem.CommandParameter = table;
        rightMenuItem.Header = "По правой стороне";
        rightMenuItem.Tag = columnIndex;
        rightMenuItem.Click += RightMenuItem_Click;
        contextMenu.Items.Add(rightMenuItem);

        MenuItem addColumnLeftMenuItem = new MenuItem();
        addColumnLeftMenuItem.CommandParameter = table;
        addColumnLeftMenuItem.Header = "Добавить колонку слева";
        addColumnLeftMenuItem.Tag = columnIndex;
        addColumnLeftMenuItem.Click += AddColumnLeftMenuItem_Click;
        contextMenu.Items.Add(addColumnLeftMenuItem);

        MenuItem addColumnRightMenuItem = new MenuItem();
        addColumnRightMenuItem.CommandParameter = table;
        addColumnRightMenuItem.Header = "Добавить колонку справа";
        addColumnRightMenuItem.Tag = columnIndex;
        addColumnRightMenuItem.Click += AddColumnRightMenuItem_Click;
        contextMenu.Items.Add(addColumnRightMenuItem);

        MenuItem deleteColumnMenuItem = new MenuItem();
        deleteColumnMenuItem.CommandParameter = table;
        deleteColumnMenuItem.Header = "Удалить колонку";
        deleteColumnMenuItem.Tag = columnIndex;
        deleteColumnMenuItem.Click += DeleteColumnMenuItem_Click; ;
        contextMenu.Items.Add(deleteColumnMenuItem);

        MenuItem deleteRowMenuItem = new MenuItem();
        deleteRowMenuItem.CommandParameter = table;
        deleteRowMenuItem.Header = "Удалить строку";
        deleteRowMenuItem.Tag = row;
        deleteRowMenuItem.Click += DeleteRowMenuItem_Click;
        contextMenu.Items.Add(deleteRowMenuItem);

        MenuItem addRowUpMenuItem = new MenuItem();
        addRowUpMenuItem.CommandParameter = table;
        addRowUpMenuItem.Tag = row;
        addRowUpMenuItem.Header = "Добавить строку сверху";
        addRowUpMenuItem.Click += AddRowUpMenuItem_Click;
        contextMenu.Items.Add(addRowUpMenuItem);

        MenuItem addRowDownMenuItem = new MenuItem();
        addRowDownMenuItem.CommandParameter = table;
        addRowDownMenuItem.Tag = row;
        addRowDownMenuItem.Header = "Добавить строку снизу";
        addRowDownMenuItem.Click += AddRowDownMenuItem_Click;
        contextMenu.Items.Add(addRowDownMenuItem);
    }

    private void AddColumnLeftMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        int column = (int)((MenuItem)sender).Tag;
        foreach (TableRow row in table.RowGroups[0].Rows)
        {
            TableCell cell = new TableCell();
            cell.BorderThickness = new Thickness(1, 1, 0, 0);
            cell.BorderBrush = Brushes.Black;
            cell.Blocks.Add(new Paragraph());

            ContextMenu contextMenu = new ContextMenu();

            AddItemsToContextMenu(contextMenu,row,table);

            cell.ContextMenu = contextMenu;
            row.Cells.Insert(column, cell);
            for(int i =0; i < row.Cells.Count; i++)
            {
                foreach(MenuItem item in row.Cells[i].ContextMenu.Items)
                {
                    if (item.Tag is int) item.Tag = i;
                }
            }
        }
    }

    private void AddColumnRightMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        int column = (int)((MenuItem)sender).Tag;
        foreach (TableRow row in table.RowGroups[0].Rows)
        {
            TableCell cell = new TableCell();
            cell.BorderThickness = new Thickness(1, 1, 0, 0);
            cell.BorderBrush = Brushes.Black;
            cell.Blocks.Add(new Paragraph());

            ContextMenu contextMenu = new ContextMenu();

            AddItemsToContextMenu(contextMenu, row, table);

            cell.ContextMenu = contextMenu;
            row.Cells.Insert(column+1, cell);
            for (int i = 0; i < row.Cells.Count; i++)
            {
                foreach (MenuItem item in row.Cells[i].ContextMenu.Items)
                {
                    if (item.Tag is int) item.Tag = i;
                }
            }
        }
    }

    private void setColumnAlligment(object sender, TextAlignment alignment)
    {
        Table table = (Table)((MenuItem)sender).CommandParameter;
        int column = (int)((MenuItem)sender).Tag;
        foreach (TableRow row in table.RowGroups[0].Rows)
        {
            row.Cells[column].TextAlignment = alignment;
        }
    }

    private void CenterMenuItem_Click(object sender, RoutedEventArgs e)
    {
        setColumnAlligment(sender, TextAlignment.Center);
    }

    private void LeftMenuItem_Click(object sender, RoutedEventArgs e)
    {
        setColumnAlligment(sender, TextAlignment.Left);
    }

    private void RightMenuItem_Click(object sender, RoutedEventArgs e)
    {
        setColumnAlligment(sender, TextAlignment.Right);
    }

    public void strikethroughItem_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        if (!Selection.IsEmpty)
        {
            var inlineList = paragraph.Inlines;
            bool bold = false;
            foreach (Inline inline in inlineList)
            {
                if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == 1 && inline.ContentEnd.CompareTo(Selection.End) == -1) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == 0 && inline.ContentEnd.CompareTo(Selection.End) == 0) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.End) == -1 && inline.ContentEnd.CompareTo(Selection.End) == 1) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == -1 && inline.ContentEnd.CompareTo(Selection.Start) == 1) bold = true;
            }

            if (bold)
            {
                Selection.ClearAllProperties();
            }
            else
            {
                var s = new Span(Selection.Start.GetInsertionPosition(LogicalDirection.Forward), Selection.End.GetInsertionPosition(LogicalDirection.Forward));
                s.TextDecorations = TextDecorations.Strikethrough;
            }
        }
    }

    public void underlineItem_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        if (!Selection.IsEmpty)
        {
            var inlineList = paragraph.Inlines;
            bool bold = false;
            foreach (Inline inline in inlineList)
            {
                if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == 1 && inline.ContentEnd.CompareTo(Selection.End) == -1) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == 0 && inline.ContentEnd.CompareTo(Selection.End) == 0) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.End) == -1 && inline.ContentEnd.CompareTo(Selection.End) == 1) bold = true;
                else if (inline is Span && inline.ContentStart.CompareTo(Selection.Start) == -1 && inline.ContentEnd.CompareTo(Selection.Start) == 1) bold = true;
            }

            if (bold)
            {
                Selection.ClearAllProperties();
            }
            else
            {
                var s = new Span(Selection.Start.GetInsertionPosition(LogicalDirection.Forward), Selection.End.GetInsertionPosition(LogicalDirection.Forward));
                s.TextDecorations = TextDecorations.Underline;
            }
        }
    }

    public void codeBlockItem_Click(object sender, RoutedEventArgs e)
    {
        Paragraph block = CaretPosition.Paragraph;
        block.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xD3, 0xD3, 0xD3));
        block.FontFamily = new FontFamily("Consolas, Lucida Sans Typewriter, Courier New");
        CaretPosition = block.ContentEnd;
    }

    public void heading1Item_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        paragraph.FontSize = 42;
        paragraph.FontWeight = FontWeights.Bold;
    }

    public void heading2Item_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        paragraph.FontSize = 20;
        paragraph.FontWeight = FontWeights.Bold;
    }

    public void heading3Item_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        paragraph.FontSize = 18;
        paragraph.FontWeight = FontWeights.Bold;
    }

    public void heading4Item_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        paragraph.FontSize = 18;
        paragraph.FontWeight = FontWeights.Light;
        paragraph.TextDecorations = TextDecorations.Underline;
    }

    public void numberedListItem_Click(object sender, RoutedEventArgs e)
    {
        List list = new List(new ListItem(new Paragraph()));
        list.MarkerStyle = TextMarkerStyle.Decimal;
        if (CaretPosition.Paragraph.Parent is ListItem)
        {
            ListItem item = (ListItem)CaretPosition.Paragraph.Parent;
            item.Blocks.Add(list);
        }
        else
        {
            Document.Blocks.InsertAfter(CaretPosition.Paragraph, list);
        }
        CaretPosition = list.ContentEnd;
    }

    public void bulletedListItem_Click(object sender, RoutedEventArgs e)
    {
        List list = new List(new ListItem(new Paragraph()));
        list.MarkerStyle = TextMarkerStyle.Disc;
        if(CaretPosition.Paragraph.Parent is ListItem)
        {
            ListItem item = (ListItem)CaretPosition.Paragraph.Parent;
            item.Blocks.Add(list);
        }
        else
        {
            Document.Blocks.InsertAfter(CaretPosition.Paragraph, list);
        }
        
        CaretPosition = list.ContentEnd;
    }

    public void quoteItem_Click(object sender, RoutedEventArgs e)
    {
        Paragraph paragraph = CaretPosition.Paragraph;
        if (paragraph.Parent is Section)
        {
            Paragraph newParagraph = new Paragraph();
            Document.Blocks.Add(newParagraph);
            Document.Blocks.InsertAfter(CaretPosition.Paragraph, newParagraph);
            CaretPosition = newParagraph.ContentEnd;
        }
        else
        {
            Section section = new Section(new Paragraph(new Run()));
            section.BorderBrush = Brushes.LightGray;
            section.BorderThickness = new Thickness(4, 0, 0, 0);
            section.Foreground = Brushes.Gray;
            section.Padding = new Thickness(16, 0, 0, 0);
            Document.Blocks.InsertAfter(CaretPosition.Paragraph, section);
            CaretPosition = section.ContentEnd;
        }
    }

    public void undoItem_Click(object sender, RoutedEventArgs e)
    {
        Undo();
    }

    public void redoItem_Click(object sender, RoutedEventArgs e)
    {
        Redo();
    }

    #endregion

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        AddImageItem = (MenuItem)GetTemplateChild("AddImageItem");
        AddLinkItem = (MenuItem)GetTemplateChild("AddLinkItem");
        AddTableItem = (MenuItem)GetTemplateChild("AddTableItem");
        BoldItem = (MenuItem)GetTemplateChild("BoldItem");
        ItalicItem = (MenuItem)GetTemplateChild("ItalicItem");
        StrikethroughItem = (MenuItem)GetTemplateChild("StrikethroughItem");
        UnderlineItem = (MenuItem)GetTemplateChild("UnderlineItem");
        CodeBlockItem = (MenuItem)GetTemplateChild("CodeBlockItem");
        Heading1Item = (MenuItem)GetTemplateChild("Heading1Item");
        Heading2Item = (MenuItem)GetTemplateChild("Heading2Item");
        Heading3Item = (MenuItem)GetTemplateChild("Heading3Item");
        Heading4Item = (MenuItem)GetTemplateChild("Heading4Item");
        BulletedListItem = (MenuItem)GetTemplateChild("BulletedListItem");
        NumberedListItem =  (MenuItem)GetTemplateChild("NumberedListItem");
        QuoteItem = (MenuItem)GetTemplateChild("QuoteItem");
        RedoItem = (MenuItem)GetTemplateChild("RedoItem");
        UndoItem = (MenuItem)GetTemplateChild("UndoItem");
    }
}
