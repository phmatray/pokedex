using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices;
using PokedexG.Uwp.Views;
using PokemonAPI;
using PokemonAPI.Models.Resources;
using Template10.Mvvm;
using Template10.Services.NavigationService;

namespace PokedexG.Uwp.ViewModels
{
    public class TypeDetailsPageViewModel : ViewModelBase
    {
        #region Constructors

        public TypeDetailsPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
            }
        }

        #endregion

        #region Properties

        public int CurrentTypeId { get; private set; }
        public TypeLite CurrentType { get; private set; }
        public List<PokemonLite> PokemonsByType { get; set; }


        public TypeResource Type { get; set; }
        public string TypeName { get; set; }
        public GenerationResource Generation { get; set; }
        public string GenerationName { get; set; }
        public List<TypeEfficacyResource> DamageFrom { get; set; }
        public List<TypeEfficacyResource> DamageTo { get; set; }

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

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Busy.SetBusy(true, "Chargement...");

            CurrentTypeId = suspensionState.ContainsKey(nameof(CurrentTypeId)) 
                ? (int)suspensionState[nameof(CurrentTypeId)]
                : (int)parameter;

            var dataFetcher = new DataFetcher();
            Type = await dataFetcher.GetType(CurrentTypeId);
            TypeName = Type.Names.FirstOrDefault(x => x.Language.Identifier == "fr")?.Name;

            DamageTo = Type.DamageFactors.Where(x => x.DamageType.Id == Type.Id).ToList();
            DamageFrom = Type.DamageFactors.Where(x => x.TargetType.Id == Type.Id).ToList();

            // TEST
            var apiResourceList = await dataFetcher.GetGenerations();
            // END OF TEST


            Generation = await dataFetcher.GetGeneration(Type.Generation.Id);
            GenerationName = Generation.Names.FirstOrDefault(x => x.Language.Identifier == "fr")?.Name;

            CurrentType = await Veekun.GetType(CurrentTypeId);
            PokemonsByType = await Veekun.GetPokemonsByType(CurrentTypeId);

            await Task.CompletedTask;

            Busy.SetBusy(false);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(CurrentTypeId)] = CurrentTypeId;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoDetailsPage(int pokemonFormId) =>
            NavigationService.Navigate(typeof(PokemonDetailsPage), pokemonFormId);

        public void GotoTypePage(int typeId) =>
            NavigationService.Navigate(typeof(TypesPage), typeId);

        #endregion
    }
}

