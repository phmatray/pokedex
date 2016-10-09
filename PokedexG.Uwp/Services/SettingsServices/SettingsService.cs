using System;
using Windows.UI.Xaml;
using PokedexG.Uwp.Views;
using Template10.Common;
using Template10.Utils;

namespace PokedexG.Uwp.Services.SettingsServices
{
    public class SettingsService
    {
        public static SettingsService Instance { get; } = new SettingsService();
        Template10.Services.SettingsService.ISettingsHelper _helper;
        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return _helper.Read(nameof(UseShellBackButton), true); }
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                    BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        public bool UsePokedexEvolutionFamilies
        {
            get { return _helper.Read(nameof(UsePokedexEvolutionFamilies), true); }
            set { _helper.Write(nameof(UsePokedexEvolutionFamilies), value); }
        }

        public bool UsePokedexMegaEvolutions
        {
            get { return _helper.Read(nameof(UsePokedexMegaEvolutions), true); }
            set { _helper.Write(nameof(UsePokedexMegaEvolutions), value); }
        }

        public bool UsePokedexAlternatives
        {
            get { return _helper.Read(nameof(UsePokedexAlternatives), true); }
            set { _helper.Write(nameof(UsePokedexAlternatives), value); }
        }

        public bool ArtworkStyle
        {
            get { return _helper.Read(nameof(ArtworkStyle), true); }
            set { _helper.Write(nameof(ArtworkStyle), value); }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = _helper.Read(nameof(AppTheme), theme.ToString());
                return Enum.TryParse(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                var frameworkElement = Window.Current.Content as FrameworkElement;
                if (frameworkElement != null)
                    frameworkElement.RequestedTheme = value.ToElementTheme();
                Shell.HamburgerMenu.RefreshStyles(value);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get { return _helper.Read(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}

