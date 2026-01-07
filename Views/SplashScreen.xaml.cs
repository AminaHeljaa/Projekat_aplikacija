namespace Projekatv2.Views;

public partial class SplashScreen : ContentPage
{
	public SplashScreen()
	{
		InitializeComponent();
	}
    private async void StartedButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}