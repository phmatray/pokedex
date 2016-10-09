using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace PokedexG.Uwp.Views.Converters
{
    public class FormKeyToIconPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return value == null
                    ? null
                    : new BitmapImage(new Uri($"ms-appx:///Assets/icons/{value}.png"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}