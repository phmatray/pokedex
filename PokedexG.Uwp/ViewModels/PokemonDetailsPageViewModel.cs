using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Services.VeekunServices.Business;
using PokedexG.Uwp.Views;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class PokemonDetailsPageViewModel : ViewModelBase
    {
        #region Constructors

        public PokemonDetailsPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
            }
        }

        #endregion

        #region Properties

        public int CurrentFormId { get; private set; }
        public PokemonDetails CurrentPokemonDetails { get; private set; }
        public PokemonFamily Family { get; private set; }
        public List<Move> Moves { get; private set; }
        public List<PokemonAbility> Abilities { get; private set; }
        public List<PokemonLocation> Locations { get; private set; }
        public List<DamageType> Weaknesses { get; set; }
        public List<PokemonEgggroup> Egggroups { get; private set; }
        public string EgggroupNames { get; private set; }

        private bool _isFromNoEggsGroup;
        public bool IsFromNoEggsGroup
        {
            get { return _isFromNoEggsGroup; }
            private set { Set(ref _isFromNoEggsGroup, value); }
        }

        private string _currentFlavorText;
        public string CurrentFlavorText
        {
            get { return _currentFlavorText; }
            private set { Set(ref _currentFlavorText, value); }
        }

        public List<PokemonLite> PokemonsByEgggroup { get; private set; }

        #endregion

        #region Commands

        //DelegateCommand<string> _readTextCommand;
        //public DelegateCommand<string> ReadTextCommand
        //    => _readTextCommand ?? (_readTextCommand = new DelegateCommand<string>(ReadTextCommandExecute, ReadTextCommandCanExecute));
        //bool ReadTextCommandCanExecute(string param) => true;
        //async void ReadTextCommandExecute(string myText)
        //{
        //    MediaElement mediaplayer = new MediaElement();
        //    using (var speech = new SpeechSynthesizer())
        //    {
        //        var readOnlyList = SpeechSynthesizer.AllVoices.ToList();
        //        speech.Voice = readOnlyList.First(gender => gender.Gender == VoiceGender.Male);
        //        SpeechSynthesisStream stream = await speech.SynthesizeTextToStreamAsync(myText);
        //        mediaplayer.SetSource(stream, stream.ContentType);
        //        mediaplayer.Play();
        //    }
        //}

        private DelegateCommand _selectFlavorTextXCommand;
        public DelegateCommand SelectFlavorTextXCommand
            => _selectFlavorTextXCommand ?? (_selectFlavorTextXCommand =
                   new DelegateCommand(() => CurrentFlavorText = CurrentPokemonDetails.FlavorTextX));
        
        private DelegateCommand _selectFlavorTextYCommand;
        public DelegateCommand SelectFlavorTextYCommand
            => _selectFlavorTextYCommand ?? (_selectFlavorTextYCommand = 
                   new DelegateCommand(() => CurrentFlavorText = CurrentPokemonDetails.FlavorTextY));
        
        private DelegateCommand _selectFlavorTextOmegaRubyCommand;
        public DelegateCommand SelectFlavorTextOmegaRubyCommand
            => _selectFlavorTextOmegaRubyCommand ?? (_selectFlavorTextOmegaRubyCommand =
                   new DelegateCommand(() => CurrentFlavorText = CurrentPokemonDetails.FlavorTextOmegaRuby));
        
        private DelegateCommand _selectFlavorTextAlphaSapphireCommand;
        public DelegateCommand SelectFlavorTextAlphaSapphireCommand
            => _selectFlavorTextAlphaSapphireCommand ?? (_selectFlavorTextAlphaSapphireCommand =
                   new DelegateCommand(() => CurrentFlavorText = CurrentPokemonDetails.FlavorTextAlphaSapphire));

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode,
            IDictionary<string, object> suspensionState)
        {
            Busy.SetBusy(true, "Chargement...");

            try
            {
                CurrentFormId = suspensionState.ContainsKey(nameof(CurrentFormId))
                    ? (int) suspensionState[nameof(CurrentFormId)]
                    : (int) parameter;

                CurrentPokemonDetails = await Veekun.GetPokemon(CurrentFormId);
                CurrentFlavorText = CurrentPokemonDetails.FlavorTextX;

                var pokemonId = CurrentPokemonDetails.PokemonId;
                var specieId = CurrentPokemonDetails.SpecieId;

                var evolutions = await Veekun.GetPokemonEvolutions(specieId);
                Family = evolutions.GetStade();

                Moves = await Veekun.GetMoves(pokemonId);
                Abilities = await Veekun.GetPokemonAbilities(pokemonId);
                Locations = await Veekun.GetPokemonLocations(pokemonId);

                Egggroups = await Veekun.GetPokemonEgggroups(specieId);
                EgggroupNames = Egggroups
                    .Select(x => x.EggGroupName)
                    .Aggregate((current, next) => current + ", " + next);

                IsFromNoEggsGroup = Egggroups.Any(x => x.EggGroupIdentifier == "no-eggs");

                if (!IsFromNoEggsGroup)
                {
                    var pokemonIds = new List<PokemonLite>();
                    foreach (var egggroup in Egggroups)
                    {
                        var list = await Veekun.GetPokemonsByEgggroup(egggroup.EggGroupId);
                        pokemonIds.AddRange(list);
                    }

                    PokemonsByEgggroup = pokemonIds
                        .GroupBy(x => x.SpecieId)
                        .Select(g => g.First())
                        .OrderBy(x => x.SpecieId)
                        .ToList();
                }
                else
                {
                    PokemonsByEgggroup = new List<PokemonLite>();
                }

                Weaknesses = await PokemonBusiness
                    .GetWeaknesses(CurrentPokemonDetails.Type1Id, CurrentPokemonDetails.Type2Id, true);

                await Task.CompletedTask;
            }
            catch (Exception)
            {
                NavigationService.Navigate(typeof(PokemonsPage));
            }

            Busy.SetBusy(false);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(CurrentFormId)] = CurrentFormId;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoPokemonDetailsPage(int pokemonFormId) =>
            NavigationService.Navigate(typeof(PokemonDetailsPage), pokemonFormId);

        public void GotoTypesPage() =>
            NavigationService.Navigate(typeof(TypesPage));

        public void GotoTypeDetailsPage(int typeId) =>
            NavigationService.Navigate(typeof(TypeDetailsPage), typeId);

        #endregion

        #region Percentiles

        private string _percentileHp;
        public async Task<string> GetPercentileHp()
        {
            return _percentileHp ??
                   (_percentileHp = CurrentPokemonDetails.CalculatePercentileHp(await Veekun.GetPokemons()));
        }

        #endregion
    }

}

