using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Data;
using PokedexG.Uwp.Models.Filtering;
using PokedexG.Uwp.Services.SettingsServices;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class PokemonsPageViewModel : ViewModelBase
    {
        #region Constructors

        public PokemonsPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                //Value = "Designtime value";
            }
            else
            {
                NameFilter = string.Empty;
            }
        }

        #endregion

        #region Properties

        private FilteredPokemonStore _pokemons;
        public FilteredPokemonStore Pokemons
        {
            get { return _pokemons; }
            set { Set(ref _pokemons, value); }
        }

        private string _pokedexName;
        public string PokedexName
        {
            get { return _pokedexName; }
            set { Set(ref _pokedexName, value); }
        }

        private string _nameFilter;
        public string NameFilter
        {
            get { return _nameFilter; }
            set
            {
                Set(ref _nameFilter, value);
                if (Pokemons != null && value != null)
                {
                    Pokemons.Filter = value;
                    Pokemons.RefreshView();
                }
            }
        }
        
        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Busy.SetBusy(true, "Chargement...");

            if (Pokemons == null)
                Pokemons = new FilteredPokemonStore(await PokemonStore.Load());

            var settingsService = SettingsService.Instance;
            Pokemons.IncludeMegaEvolutions = settingsService.UsePokedexMegaEvolutions;
            Pokemons.IncludeAlternatives = settingsService.UsePokedexAlternatives;
            Pokemons.SortMethod = settingsService.UsePokedexEvolutionFamilies
                ? PokemonSorting.ByEvolution
                : PokemonSorting.ByNumber;
            Pokemons.Filter = NameFilter;
            Pokemons.RefreshView();

            var pokedexes = await Veekun.GetPokedexesAsync();
            PokedexName = pokedexes?.First()?.Description ?? "Pokédex";

            Busy.SetBusy(false);
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

        public void Hasardex()
        {
            var pokemonFormId = Pokemons.PickRandom().FormId;
            NavigationService.Navigate(typeof(PokemonDetailsPage), pokemonFormId);
        }

        public void GotoPokemonDetailsPage(int pokemonFormId) =>
            NavigationService.Navigate(typeof(PokemonDetailsPage), pokemonFormId);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(SettingsPage), 0);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(SettingsPage), 1);

        #endregion
    }
}

