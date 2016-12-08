using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices.Business;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlType2
    {
        public UserControlType2()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty PokemonTypeProperty = DependencyProperty.Register(
            "PokemonType", typeof(PokemonTypeUiModel), typeof(UserControlType2), new PropertyMetadata(default(PokemonTypeUiModel)));

        public PokemonTypeUiModel PokemonType
        {
            get { return (PokemonTypeUiModel) GetValue(PokemonTypeProperty); }
            set
            {
                if (value != null)
                {
                    Background = new SolidColorBrush(ColorCodes.GetColorByTypeId(value.Id));
                    Text = value.Name.ToUpper();
                }

                SetValue(PokemonTypeProperty, value);
            }
        }

        private static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(UserControlType2), new PropertyMetadata(default(string)));

        private string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value?.ToUpper()); }
        }

        public new static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
            "FontSize", typeof(double), typeof(UserControlType2), new PropertyMetadata(default(double)));

        public new double FontSize
        {
            get { return (double) GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
    }
}
