using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace GrblExpress.Converters
{
    public class IntEqualsConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) => value is int i && parameter is string s && int.TryParse(s, out var val) && i == val;
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b && b && parameter is string s && int.TryParse(s, out var val))
                return val;
            return Avalonia.Data.BindingOperations.DoNothing;
        }
    }

}
