using Avalonia;
using Avalonia.Data.Converters;
using GrblExpress.Common.Types;
using System;
using System.Globalization;

namespace GrblExpress.Converters
{
    class BaudEnumStringConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is BaudRate baudRate)
            {
                return baudRate.ToString().Replace("Baud", string.Empty);
            }
            return AvaloniaProperty.UnsetValue;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is BaudRate baudRate) return value;

            if (value is string str && Enum.TryParse("Baud" + str, out BaudRate parsed))
            {
                return parsed;
            }
            return AvaloniaProperty.UnsetValue;
        }
    }
}
