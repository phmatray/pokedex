using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PokemonAPI;
using PokemonAPI.Models.Resources;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class GamesPageViewModel : ViewModelBase
    {
        #region Constructors

        public GamesPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //Value = "Designtime value";
            }
            else
            {
            }
        }

        #endregion

        #region Properties

        private List<APIResourceBase> _generations;
        public List<APIResourceBase> Generations
        {
            get { return _generations; }
            set { Set(ref _generations, value); }
        }

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var apiResourceList = await new DataFetcher().GetGenerations();
            Generations = apiResourceList.Results;

            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        #endregion
    }
}

