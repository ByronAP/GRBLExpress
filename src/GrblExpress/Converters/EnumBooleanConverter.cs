using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace GrblExpress.Converters
{
    public class EnumBooleanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            string enumValue = parameter.ToString()!;
            return value.ToString() == enumValue;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked && parameter != null)
            {
                return Enum.Parse(targetType, parameter.ToString()!);
            }
            return AvaloniaProperty.UnsetValue;
        }
    }
}
