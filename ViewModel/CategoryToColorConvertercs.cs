using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Projekatv2.ViewModel
{
    public class CategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedCategory = value as string;
            string buttonCategory = parameter as string;

            if (selectedCategory == buttonCategory)
                return Color.FromArgb("#F4B400");
            else
                return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
