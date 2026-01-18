namespace Projekatv2.Views;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage()
	{
		InitializeComponent();
	}
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var idString = Preferences.Get("userId", null);
        if (idString == null) return;

        int id = int.Parse(idString);

        string newName = NameEntry.Text;

        if (string.IsNullOrWhiteSpace(newName))
        {
            await DisplayAlert("Greška", "Unesi ime!", "OK");
            return;
        }

        CommonSettings.Service.UpdateUserName(id, newName);

        await DisplayAlert("Sa?uvano", "Ime je uspješno promijenjeno!", "OK");

        await Navigation.PopAsync(); // vra?a na ProfilePage
    }
}