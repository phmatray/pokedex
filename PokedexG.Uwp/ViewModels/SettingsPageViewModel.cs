using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Uwp.Services.Facebook;
using PokedexG.Uwp.Views;
using Template10.Mvvm;

namespace PokedexG.Uwp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        #region Constructors

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        #endregion

        #region Properties

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set
            {
                _settings.UseShellBackButton = value;
                RaisePropertyChanged();
            }
        }

        public bool UsePokedexEvolutionFamilies
        {
            get { return _settings.UsePokedexEvolutionFamilies; }
            set
            {
                _settings.UsePokedexEvolutionFamilies = value;
                RaisePropertyChanged();
            }
        }

        public bool UsePokedexMegaEvolutions
        {
            get { return _settings.UsePokedexMegaEvolutions; }
            set
            {
                _settings.UsePokedexMegaEvolutions = value;
                RaisePropertyChanged();
            }
        }

        public bool UsePokedexAlternatives
        {
            get { return _settings.UsePokedexAlternatives; }
            set
            {
                _settings.UsePokedexAlternatives = value;
                RaisePropertyChanged();
            }
        }

        public bool ArtworkStyle
        {
            get { return _settings.ArtworkStyle; }
            set
            {
                _settings.ArtworkStyle = value;
                RaisePropertyChanged();
            }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set
            {
                _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                RaisePropertyChanged();
            }
        }

        private string _busyText = "Please wait...";
        public string BusyText
        {
            get { return _busyText; }
            set
            {
                Set(ref _busyText, value);
                _showBusyCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        DelegateCommand _showBusyCommand;
        public DelegateCommand ShowBusyCommand
            => _showBusyCommand ?? (_showBusyCommand = new DelegateCommand(async () =>
            {
                Busy.SetBusy(true, _busyText);
                await Task.Delay(5000);
                Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(BusyText)));

        //DelegateCommand _ClearCacheCommand;
        //public DelegateCommand ClearCacheCommand
        //    => _ClearCacheCommand ?? (_ClearCacheCommand = new DelegateCommand(async () =>
        //    {
        //        Views.Busy.SetBusy(true, "Nous vidons le cache...");
        //        await PokemonCacheHelper.ClearLocalCacheFolder();
        //        Views.Busy.SetBusy(false);
        //    }));

        #endregion
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://aka.ms/template10");

        DelegateCommand<string> _shareOnFacebookCommand;
        public DelegateCommand<string> ShareOnFacebookCommand
            => _shareOnFacebookCommand ?? (_shareOnFacebookCommand = new DelegateCommand<string>(ShareOnFacebookCommandExecute, ShareOnFacebookCommandCanExecute));

        bool ShareOnFacebookCommandCanExecute(string param) => true;

        async void ShareOnFacebookCommandExecute(string myText)
        {
            FacebookService.Instance.Initialize("1788284271387711");

            // Login to Facebook
            if (!await FacebookService.Instance.LoginAsync())
            {
                return;
            }

            // Post a message on your wall
            var result = await FacebookService.Instance.PostToFeedAsync(
                "Pokédex G",
                "Pokédex G sur Windows 10",
                "Le Pokédex 6G en français est le compagnon idéal pour découvrir tous les pokémons de vos jeux 3DS.",
                "https://www.microsoft.com/fr-fr/store/p/pokedex-g/9nblggh516gc");

            if (result)
            {
                var messageDialog = new MessageDialog("Merci d'avoir partagé votre intérêt pour Pokédex G");
                await messageDialog.ShowAsync();
            }
        }
    }
}

