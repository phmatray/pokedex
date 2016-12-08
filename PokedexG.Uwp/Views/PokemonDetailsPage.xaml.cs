using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.ViewModels;

namespace PokedexG.Uwp.Views
{
    public sealed partial class PokemonDetailsPage
    {
        public PokemonDetailsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        private void BreedingElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var pokemonFormId = ((PokemonLite)((FrameworkElement)sender).DataContext).SpecieId;
            ((PokemonDetailsPageViewModel)DataContext).GotoPokemonDetailsPage(pokemonFormId);
        }

        private void Type1_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var type1 = ((PokemonDetailsPageViewModel)((FrameworkElement)sender).DataContext).Pokemon.Type1.Id;
            ((PokemonDetailsPageViewModel)DataContext).GotoTypeDetailsPage(type1);
        }

        private void Type2_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var type2 = ((PokemonDetailsPageViewModel)((FrameworkElement)sender).DataContext).Pokemon.Type2.Id;
            ((PokemonDetailsPageViewModel)DataContext).GotoTypeDetailsPage(type2);
        }

        private void WeaknessType_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var type = ((DamageType) ((FrameworkElement)sender).DataContext).DamageTypeId;
            ((PokemonDetailsPageViewModel)DataContext).GotoTypeDetailsPage(type);
        }

        private void Evolution_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var pokemonEvolution = ((PokemonFamilyStade)((FrameworkElement)sender).DataContext).Evolutions[0];
            var pokemonId = pokemonEvolution.PokemonId;

            //pokemonFormId
            ((PokemonDetailsPageViewModel)DataContext).GotoPokemonDetailsPage(pokemonId);
        }

        private void GifImage_OnImageOpened(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

