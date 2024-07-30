using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Project_PRN212
{
    public class PageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentPage = value as string;
            var buttonPage = parameter as string;

            if (currentPage == buttonPage)
            {
                return new SolidColorBrush(Color.FromRgb(46, 204, 113)); // Highlight color
            }

            return new SolidColorBrush(Color.FromRgb(52, 73, 94)); // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
