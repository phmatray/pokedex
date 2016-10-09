using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using PokedexG.Uwp.Utils;

namespace PokedexG.Uwp.Views.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ConverterHelper.TryParseInt(value) != 0
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}