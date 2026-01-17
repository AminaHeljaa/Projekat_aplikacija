using Projekatv2.Views;

namespace Projekatv2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NarudzbaPage), typeof(NarudzbaPage));
        }
    }
}
