using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using ColorHelper = Microsoft.Toolkit.Uwp.ColorHelper;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlDamageFactor
    {
        public UserControlDamageFactor()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public new static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(
            "Background", typeof(SolidColorBrush), typeof(UserControlDamageFactor), new PropertyMetadata(default(SolidColorBrush)));

        public new SolidColorBrush Background
        {
            get { return (SolidColorBrush) GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }


        public new static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
            "Foreground", typeof(SolidColorBrush), typeof(UserControlDamageFactor), new PropertyMetadata(default(SolidColorBrush)));

        public new SolidColorBrush Foreground
        {
            get { return (SolidColorBrush) GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }


        public static readonly DependencyProperty DamageFactorProperty = DependencyProperty.Register(
            "DamageFactor", typeof(string), typeof(UserControlDamageFactor), new PropertyMetadata(default(string)));

        public string DamageFactor
        {
            get { return (string) GetValue(DamageFactorProperty); }
            set
            {
                switch (value)
                {
                    case "0":
                        value = "0";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#FF000000"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                        break;
                    case "25":
                        value = "0.25";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#FFC02000"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                        break;
                    case "50":
                        value = "0.5";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#FFF05030"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                        break;
                    case "100":
                        value = "1";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#00000000"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FF000000"));
                        break;
                    case "200":
                        value = "2";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#FF78C850"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                        break;
                    case "400":
                        value = "4";
                        Background = new SolidColorBrush(ColorHelper.ToColor("#FF489820"));
                        Foreground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                        break;
                }

                SetValue(DamageFactorProperty, value);
            }
        }
    }
}
