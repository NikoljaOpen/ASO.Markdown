using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ASO.Markdown.Controls;

public class LinkedImageControl : Image
{
    public static readonly DependencyProperty UrlProperty = DependencyProperty.Register(
        "Url", typeof(string), typeof(LinkedImageControl), new PropertyMetadata(null));

    public string Url
    {
        get { return (string)GetValue(UrlProperty); }
        set { SetValue(UrlProperty, value); }
    }



    public LinkedImageControl()
    {

    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        if (!string.IsNullOrEmpty(Url))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Url,
                UseShellExecute = true
            });
        }
        else
        {
            base.OnMouseDown(e);
        }
    }
}
