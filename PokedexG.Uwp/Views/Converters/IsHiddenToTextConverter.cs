using System;
using Windows.UI.Xaml.Data;

namespace PokedexG.Uwp.Views.Converters
{
    public class IsHiddenToTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return (bool) value ? "(Caché)" : "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}