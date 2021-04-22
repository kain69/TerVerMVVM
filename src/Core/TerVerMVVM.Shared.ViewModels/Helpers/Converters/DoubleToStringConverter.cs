using System;
using System.Globalization;
using System.Windows.Data;

namespace TerVerMVVM.Shared.ViewModels
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null)
                ? String.Empty
                : ((double)value).ToString("0.####");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse((string)value);
        }
    }
}
