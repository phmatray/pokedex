using System;
using Windows.UI.Xaml.Data;

namespace PokedexG.Uwp.Views.Converters
{
    public class StringToRemoveBreakConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString().Replace('\n', ' ');
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}