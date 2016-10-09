using Windows.UI.Xaml;
using PokedexG.Uwp.Models;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
// http://blog.jerrynixon.com/2013/07/solved-two-way-binding-inside-user.html

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlEvolution
    {
        public UserControlEvolution()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty PokemonFamilyProperty = DependencyProperty.Register(
            "PokemonFamily", typeof(PokemonFamily), typeof(UserControlEvolution), new PropertyMetadata(default(PokemonFamily)));

        public PokemonFamily PokemonFamily
        {
            get { return (PokemonFamily) GetValue(PokemonFamilyProperty); }
            set { SetValue(PokemonFamilyProperty, value); }
        }
    }
}
