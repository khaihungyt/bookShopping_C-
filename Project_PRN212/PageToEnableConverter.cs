using System;
using System.Globalization;
using System.Windows.Data;

namespace Project_PRN212
{
    public class PageToEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentPage = value as string;
            var buttonPage = parameter as string;

            return currentPage != buttonPage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
