using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace PokedexG.Uwp.Views.Converters
{
    public class SpecieIdToSpritePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value == null
                ? new BitmapImage()
                : new BitmapImage(new Uri($"ms-appx:///Assets/sprites/{value}.gif"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}