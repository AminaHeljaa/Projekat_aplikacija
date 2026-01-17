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
        // Naziv lokacije
        var placeName = "Palaèinkara Slatki zalogaj Zenica";

        // Google Maps pretraga po nazivu (najpreciznije)
        var url = $"https://www.google.com/maps/search/?api=1&query={Uri.EscapeDataString(placeName)}";

        await Launcher.OpenAsync(url);
    }



}