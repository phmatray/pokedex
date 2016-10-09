using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Microsoft.HockeyApp;
using PokedexG.Uwp.Services.SettingsServices;
using PokedexG.Uwp.Views;
using Template10.Common;
using Template10.Controls;

namespace PokedexG.Uwp
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Splash(e);

            #region App settings

            var settings = SettingsService.Instance;
            RequestedTheme = settings.AppTheme;
            CacheMaxDuration = settings.CacheMaxDuration;
            ShowShellBackButton = settings.UseShellBackButton;

            #endregion

            HockeyClient.Current.Configure("023c2690e8e246fb87f2efecba480647");
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if (!(Window.Current.Content is ModalDialog))
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);

                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Shell(nav),
                    ModalContent = new Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await CopyDatabase();

            if (startKind == StartKind.Activate)
            {
                if (args.Kind == ActivationKind.Protocol)
                {
                    var protocolArgs = args as ProtocolActivatedEventArgs;
                    var host = protocolArgs?.Uri?.Host;
                    var formId = protocolArgs?.Uri?.LocalPath.Trim('/');

                    if (host == "pokemons" && !string.IsNullOrWhiteSpace(formId))
                    {
                        int result;
                        int.TryParse(formId, out result);
                        NavigationService.Navigate(typeof(PokemonDetailsPage), result);
                    }
                    else
                    {
                        NavigationService.Navigate(typeof(PokemonsPage));
                    }
                }
            }
            else
            {
                // long-running startup tasks go here
                //await Task.Delay(5000);

                NavigationService.Navigate(typeof(PokemonsPage));
            }

            await Task.CompletedTask;
        }

        private async Task CopyDatabase()
        {
            const string fileName = Constants.DatabaseName;
            var localFolder = ApplicationData.Current.LocalFolder;
            var isDatabaseExisting = false;

            try
            {
                var storageFile = await localFolder.GetFileAsync(fileName);
                isDatabaseExisting = true;
            }
            catch
            {
                isDatabaseExisting = false;
            }

            if (!isDatabaseExisting)
            {
                var folder = Package.Current.InstalledLocation;
                folder = await folder.GetFolderAsync("Data");

                var file = await folder.GetFileAsync(fileName);
                await file.CopyAsync(localFolder);
            }
        }
    }
}

