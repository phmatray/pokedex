using System.Collections.Generic;
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
    public class TypesPageViewModel : ViewModelBase
    {
        #region Constructors

        public TypesPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
            }
        }

        #endregion

        #region Properties

        public int CurrentTypeId { get; private set; }
        public List<TypeRelation> TypeRelations { get; private set; }
        public List<TypeLite> Types { get; private set; }
        public List<TypeRelationGroup> TypeRelationsGroups { get; private set; }

        #endregion

        #region Commands

        #endregion

        #region Navigation

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Busy.SetBusy(true, "Chargement...");

            //CurrentTypeId = suspensionState.ContainsKey(nameof(CurrentTypeId)) 
            //    ? (int)suspensionState[nameof(CurrentTypeId)]
            //    : (int)parameter;

            TypeRelations = await Veekun.GetTypeRelations();
            Types = await Veekun.GetTypeLites();
            //var typesX = types.Select(x => x.)

            TypeRelationsGroups = TypeRelations
                .GroupBy(x => x.DamageTypeId)
                .Select((group, i) => new TypeRelationGroup {Type = Types[i], TypeRelations = group.ToList()})
                .ToList();

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

        public void GotoTypeDetailsPage(int typeId) =>
            NavigationService.Navigate(typeof(TypeDetailsPage), typeId);

        #endregion
    }
}

