using Windows.UI.Xaml;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
// http://blog.jerrynixon.com/2013/07/solved-two-way-binding-inside-user.html

namespace PokedexG.Uwp.Views.UserControls
{
    public sealed partial class UserControlTitle
    {
        public UserControlTitle()
        {
            InitializeComponent();

            var frameworkElement = Content as FrameworkElement;
            if (frameworkElement != null) frameworkElement.DataContext = this;
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(UserControlTitle), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}
