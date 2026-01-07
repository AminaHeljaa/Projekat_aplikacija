namespace Projekatv2.Views;
using Microsoft.Maui.ApplicationModel;

public partial class LocationPage : ContentPage
{
    
    public LocationPage()
    {

        InitializeComponent();

      
    }
    private async void OpenGoogleMaps_Clicked(object sender, EventArgs e)
    {

        // Koordinate 
        var latitude = 44.2034;
        var longitude = 17.9077;

        // Direktno otvara lokaciju sa pinom
        var url = $"https://www.google.com/maps/place/{latitude},{longitude}";


        // Otvori URL u web pregledniku
        await Launcher.OpenAsync(url);
    }


}