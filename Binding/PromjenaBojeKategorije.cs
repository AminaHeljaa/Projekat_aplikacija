using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Projekatv2.Binding
{
    public class CategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedCategory = value as string;
            string buttonCategory = parameter as string;

            if (selectedCategory == buttonCategory)
                return new SolidColorBrush(Color.FromArgb("#F4B400"));
            else
                return Brush.Transparent;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
