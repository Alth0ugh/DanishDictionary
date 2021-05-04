using DanishDictionary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DanishDictionary.Converters
{
    class ArticleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Articles))
            {
                return string.Empty;
            }
            var article = (Articles)value;

            if (article == Articles.En)
            {
                return "en";
            }
            else
            {
                return "et";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Articles.En;
        }
    }
}
