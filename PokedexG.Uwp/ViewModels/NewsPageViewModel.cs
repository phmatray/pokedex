using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Services.Bing;
using PokedexG.Uwp.Utils;
using PokedexG.Uwp.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        #region Constructors

        public NewsPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //Value = "Designtime value";
            }
            else
            {
                //LoadData();
            }

            BingResults = new ObservableCollection<BingResult>();
        }

        #endregion

        #region Properties

        public ObservableCollection<BingResult> BingResults { get; }

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode,
            IDictionary<string, object> suspensionState)
        {
            if (await NetworkHelper.CheckInternetConnection())
            {
                Busy.SetBusy(true, "Chargement...");

                var bingResults = await WebNewsHelper.GetBingPokemonSearch();
                BingResults.Clear();
                foreach (var bingResult in bingResults)
                    BingResults.Add(bingResult);

                Busy.SetBusy(false);
            }

            if (suspensionState.Any())
            {
                //Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                //suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        #endregion

        #region PrivateMethods

        //private async void LoadData()
        //{
        //}

        #endregion
    }
}

