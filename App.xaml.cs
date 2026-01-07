namespace Projekatv2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(
                      new NavigationPage(new Views.SplashScreen())
   );
        }
        /*
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }*/
    }
}