using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.ViewModels;

namespace PokedexG.Uwp.Views
{
    public sealed partial class TypeDetailsPage
    {
        public TypeDetailsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        private void PokemonElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var pokemonFormId = ((PokemonLite)((FrameworkElement)sender).DataContext).PokemonId;
            ((TypeDetailsPageViewModel)DataContext).GotoDetailsPage(pokemonFormId);
        }
    }
}

