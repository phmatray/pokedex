using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.ViewModels;

namespace PokedexG.Uwp.Views
{
    public sealed partial class GalleryPage
    {
        public GalleryPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void AdaptiveGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonFormId = ((Pokemon)e.ClickedItem).FormId;
            ((PokemonsPageViewModel)DataContext).GotoPokemonDetailsPage(pokemonFormId);
        }
    }
}
