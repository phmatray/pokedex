using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.ViewModels;

namespace PokedexG.Uwp.Views
{
    public sealed partial class TypesPage
    {
        public TypesPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        private void Type_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var typeId = ((TypeRelationGroup)((FrameworkElement)sender).DataContext).Type.Id;
            ((TypesPageViewModel)DataContext).GotoTypeDetailsPage(typeId);
        }

        private void Type2_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var typeId = ((TypeLite)((FrameworkElement)sender).DataContext).Id;
            ((TypesPageViewModel)DataContext).GotoTypeDetailsPage(typeId);
        }
    }
}

