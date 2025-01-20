
namespace MauiBugVSMFocus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            var fp = new FlyoutPage
            {
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover,
                Detail = new NavigationPage(new MainPage()),
                Flyout = new NewPage1()
            };
            return new Window(fp);
        }
        public INavigation GetNavigation()
        {
            if (this.Windows[0].Page is FlyoutPage fp && fp.Detail is NavigationPage np)
            {
                return np.Navigation;
            }
            throw new Exception("There are no FlyoutPage->NavigationPage");
        }
    }
}