using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace ASO.Markdown;

public class IconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IconType iconType)
        {
            var icon = IconLibrary.Icons[iconType];

            return icon;
        }

        return Binding.DoNothing;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

