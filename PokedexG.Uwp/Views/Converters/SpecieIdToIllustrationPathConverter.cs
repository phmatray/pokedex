using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using PokedexG.Uwp.Services.SettingsServices;

namespace PokedexG.Uwp.Views.Converters
{
    public class SpecieIdToIllustrationPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var artworkStyle = SettingsService.Instance.ArtworkStyle ? "sugimori" : "globallink";

            return value == null
                ? new BitmapImage()
                : new BitmapImage(new Uri($"ms-appx:///Assets/{artworkStyle}/{value}.jpg"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}