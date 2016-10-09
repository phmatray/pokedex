using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using PokedexG.Uwp.Utils;

namespace PokedexG.Uwp.Views.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visibility = Visibility.Collapsed;
            if (value is bool && (bool)value)
                visibility = Visibility.Visible;

            if (ConverterHelper.TryParseBool(parameter))
                return visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
