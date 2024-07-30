using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PRN212_Assignment
{
    public class PageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentPage = value as string;
            string buttonPage = parameter as string;
            return currentPage == buttonPage ? Brushes.White : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#34495E"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PageToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentPage = value as string;
            string buttonPage = parameter as string;
            return currentPage == buttonPage ? Brushes.Black : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PageToIsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentPage = value as string;
            string buttonPage = parameter as string;
            return currentPage != buttonPage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
