namespace Projekatv2.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}
    private async void SupportEmail_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("mailto:podrska@slatkizalogaj.ba?subject=Pomoc - Slatki zalogaj");
    }
}