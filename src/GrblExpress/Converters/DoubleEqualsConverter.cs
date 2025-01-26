using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace GrblExpress.Converters
{
    public class DoubleEqualsConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) => value is double d && parameter is string s && double.TryParse(s, out var val) && Math.Abs(d - val) < 0.0001;
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // If "IsChecked" is true, return the parameter as a double; otherwise ignore
            if (value is bool b && b && parameter is string s && double.TryParse(s, out var val))
                return val;
            return Avalonia.Data.BindingOperations.DoNothing;
        }
    }
}
