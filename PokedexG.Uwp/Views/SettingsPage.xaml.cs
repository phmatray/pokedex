using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace PokedexG.Uwp.Views
{
    public sealed partial class SettingsPage
    {
        Template10.Services.SerializationService.ISerializationService _SerializationService;

        public SettingsPage()
        {
            InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private async void ReviewApp_OnClick(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?ProductId=9NBLGGH516GC"));
        }
    }
}
