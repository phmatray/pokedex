using System;
using Windows.UI.Xaml.Data;

namespace PokedexG.Uwp.Views.Converters
{
    public class PlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is Int32 && (int) value == default(int))
                    return "--";

                var s = value as string;
                if (string.IsNullOrWhiteSpace(s))
                    return "--";

                var p = parameter as string;
                return p != null ? string.Format((string)parameter, value) : value;
            }
            catch (Exception)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}