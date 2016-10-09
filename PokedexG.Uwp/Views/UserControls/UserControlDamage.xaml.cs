using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using PokedexG.Uwp.Services.VeekunServices.Business;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlDamage
    {
        public UserControlDamage()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty DamageClassIdentifierProperty = DependencyProperty.Register(
            "DamageClassIdentifier", typeof(string), typeof(UserControlDamage), new PropertyMetadata(default(string)));

        public string DamageClassIdentifier
        {
            get { return (string) GetValue(DamageClassIdentifierProperty); }
            set
            {
                switch (value)
                {
                    case "status":
                        Text = "Status";
                        break;
                    case "physical":
                        Text = "Physique";
                        break;
                    case "special":
                        Text = "Spécial";
                        break;
                    default:
                        Text = "";
                        break;
                }
                Background = new SolidColorBrush(ColorCodes.GetColorByDamageIdentifier(value));
                SetValue(DamageClassIdentifierProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(UserControlDamage), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value?.ToUpper()); }
        }
    }
}
