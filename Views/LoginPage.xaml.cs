namespace Projekatv2.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string Email = EntryMail.Text;
        string Password = EntryPass.Text;

        bool jeUspjesno = await CommonSettings.Service.TryLogin(Email, Password);
        {
            if (jeUspjesno)
            {/*
                Application.Current.MainPage = new NavigationPage(new MainPage());*/
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Greška", "Email ili password nisu tacni", "OK");
            }
        }
    }
}