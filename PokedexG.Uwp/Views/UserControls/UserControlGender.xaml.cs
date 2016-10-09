using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using ColorHelper = Microsoft.Toolkit.Uwp.ColorHelper;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlGender
    {
        public UserControlGender()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty GenderCodeProperty = DependencyProperty.Register(
            "GenderCode", typeof(int), typeof(UserControlGender), new PropertyMetadata(default(int)));

        public int GenderCode
        {
            get { return (int) GetValue(GenderCodeProperty); }
            set
            {
                var color = ColorHelper.ToColor(value < 0 ? "#FF888888" : "#FF2FA0FF");
                BackgroundBrush = new SolidColorBrush(color);
                SetValue(GenderCodeProperty, value);
            }
        }

        public static readonly DependencyProperty BackgroundBrushProperty = DependencyProperty.Register(
            "BackgroundBrush", typeof(SolidColorBrush), typeof(UserControlGender), new PropertyMetadata(default(SolidColorBrush)));

        public SolidColorBrush BackgroundBrush
        {
            get { return (SolidColorBrush) GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }
    }
}
