using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.ViewModels;

namespace PokedexG.Uwp.Views
{
    public sealed partial class PokemonsPage
    {
        public PokemonsPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void PokemonItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var pokemonFormId = ((Pokemon) ((FrameworkElement) sender).DataContext).FormId;
            ((PokemonsPageViewModel)DataContext).GotoPokemonDetailsPage(pokemonFormId);
        }
    }
}
