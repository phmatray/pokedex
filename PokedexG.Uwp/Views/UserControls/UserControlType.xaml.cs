using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using PokedexG.Uwp.Services.VeekunServices.Business;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlType
    {
        public UserControlType()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty TypeIdProperty = DependencyProperty.Register(
            "TypeId", typeof(int), typeof(UserControlType), new PropertyMetadata(default(int)));

        public int TypeId
        {
            get { return (int) GetValue(TypeIdProperty); }
            set
            {
                Background = new SolidColorBrush(ColorCodes.GetColorByTypeId(value));
                SetValue(TypeIdProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(UserControlType), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value?.ToUpper()); }
        }

        public new static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
            "FontSize", typeof(double), typeof(UserControlType), new PropertyMetadata(default(double)));

        public new double FontSize
        {
            get { return (double) GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
    }
}
