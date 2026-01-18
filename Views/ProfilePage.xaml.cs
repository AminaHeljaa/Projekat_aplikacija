using System.Xml;
using Microsoft.Maui.Storage;
namespace Projekatv2;
using Projekatv2.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        LoadUser();
    }
    
    private void LoadUser()
    {
        var idString = Preferences.Get("userId", null);

        if (idString == null)
            return;

        int id = int.Parse(idString);

        var user = CommonSettings.Service.GetUserById(id);

        if (user != null)
        {
            nameLabel.Text = user.FullName;
            emailLabel.Text = user.Email;
        }

        // Postavi profilnu sliku
        profileImage.Source = user.ProfileImage;
    }

    private void Logout_Clicked(object sender, EventArgs e)
    {
        
        Preferences.Remove("userId");
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }

    private async void EditProfile_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditProfilePage());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadUser();   // ponovo u?ita podatke kad se vratiš sa EditProfile
    }

    private async void TapHelp_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new HelpPage());
    }
}