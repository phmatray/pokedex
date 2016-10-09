using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using PokedexG.Uwp.Models;
using PokedexG.Uwp.Services.VeekunServices.Business;
using ColorHelper = Microsoft.Toolkit.Uwp.ColorHelper;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlWeakness
    {
        public UserControlWeakness()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty DamageProperty = DependencyProperty.Register(
            "Damage", typeof(DamageType), typeof(UserControlWeakness), new PropertyMetadata(default(DamageType)));

        public DamageType Damage
        {
            get { return (DamageType) GetValue(DamageProperty); }
            set
            {
                if (value != null)
                {
                    DamageTypeName = value.DamageTypeName.ToUpper();
                    SetDamageFactor(value.DamageFactor);
                    Background = new SolidColorBrush(ColorCodes.GetColorByTypeId(value.DamageTypeId));
                }
                SetValue(DamageProperty, value);
            }
        }

        private static readonly DependencyProperty DamageTypeNameProperty = DependencyProperty.Register(
            "DamageTypeName", typeof(string), typeof(UserControlWeakness), new PropertyMetadata(default(string)));

        private string DamageTypeName
        {
            get { return (string) GetValue(DamageTypeNameProperty); }
            set { SetValue(DamageTypeNameProperty, value); }
        }

        private static readonly DependencyProperty DamageFactorProperty = DependencyProperty.Register(
            "DamageFactor", typeof(string), typeof(UserControlWeakness), new PropertyMetadata(default(string)));

        private string DamageFactor
        {
            get { return (string) GetValue(DamageFactorProperty); }
            set { SetValue(DamageFactorProperty, value); }
        }

        private static readonly DependencyProperty DamageFactorBackgroundProperty = DependencyProperty.Register(
            "DamageFactorBackground", typeof(SolidColorBrush), typeof(UserControlWeakness), new PropertyMetadata(default(SolidColorBrush)));

        private SolidColorBrush DamageFactorBackground
        {
            get { return (SolidColorBrush) GetValue(DamageFactorBackgroundProperty); }
            set { SetValue(DamageFactorBackgroundProperty, value); }
        }

        private static readonly DependencyProperty DamageFactorForegroundProperty = DependencyProperty.Register(
            "DamageFactorForeground", typeof(SolidColorBrush), typeof(UserControlWeakness), new PropertyMetadata(default(SolidColorBrush)));

        private SolidColorBrush DamageFactorForeground
        {
            get { return (SolidColorBrush) GetValue(DamageFactorForegroundProperty); }
            set { SetValue(DamageFactorForegroundProperty, value); }
        }

        private void SetDamageFactor(int damageFactor)
        {
            switch (damageFactor)
            {
                case 0:
                    DamageFactor = "0";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#FF000000"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                    break;
                case 25:
                    DamageFactor = "/4";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#FF489820"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                    break;
                case 50:
                    DamageFactor = "/2";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#FF78C850"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                    break;
                case 100:
                    DamageFactor = "1";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#00000000"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FF000000"));
                    break;
                case 200:
                    DamageFactor = "x2";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#FFF05030"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                    break;
                case 400:
                    DamageFactor = "x4";
                    DamageFactorBackground = new SolidColorBrush(ColorHelper.ToColor("#FFC02000"));
                    DamageFactorForeground = new SolidColorBrush(ColorHelper.ToColor("#FFFFFFFF"));
                    break;
            }
        }
    }
}
