using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class MachinesPageViewModel : ViewModelBase
    {
        #region Constructors

        public MachinesPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //Value = "Designtime value";
            }
            else
            {
                LoadData();
            }
        }

        #endregion

        #region Properties

        private ObservableCollection<Machine> _machines;
        public ObservableCollection<Machine> Machines
        {
            get { return _machines; }
            private set { Set(ref _machines, value); }
        }

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
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

        //public void GotoDetailsPage() =>
        //    NavigationService.Navigate(typeof(Views.DetailPage), CurrentPokemon);

        #endregion

        #region PrivateMethods

        private async void LoadData()
        {
            Busy.SetBusy(true, "Chargement...");
            var machines = await Veekun.GetMachines();
            Machines = new ObservableCollection<Machine>(machines);
            Busy.SetBusy(false);
        }

        #endregion
    }
}

