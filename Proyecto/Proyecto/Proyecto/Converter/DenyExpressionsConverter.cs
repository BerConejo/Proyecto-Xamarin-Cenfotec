using System;
using System.Globalization;
using Xamarin.Forms;

namespace Proyecto.Converter
{
    public class DenyExpressionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(Boolean))
            {
                Boolean p = (Boolean)value;
                return !p;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
