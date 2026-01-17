using Microsoft.Maui.Controls;
using Projekatv2.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Projekatv2.Views;

public partial class NarudzbaPage : ContentPage
{
    public NarudzbaPage()
    {
        InitializeComponent();
    }

    private async void OnBackToCart(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnConfirmOrderClicked(object sender, EventArgs e)
    {
        // Prazna polja
        if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
            string.IsNullOrWhiteSpace(PhoneEntry.Text) ||
            string.IsNullOrWhiteSpace(AddressEntry.Text) ||
            string.IsNullOrWhiteSpace(CardNumberEntry.Text) ||
            string.IsNullOrWhiteSpace(CVVEntry.Text) ||
            string.IsNullOrWhiteSpace(CardNameEntry.Text))
        {
            await DisplayAlert("Greška", "Molimo popunite sva polja!", "OK");
            return;
        }

        // Validacija imena/prezimena (samo slova, prvo veliko)
        if (!Regex.IsMatch(FirstNameEntry.Text, @"^[A-ZŠÐÈÆŽ][a-zšðèæž]+$"))
        {
            await DisplayAlert("Greška", "Ime mora poèeti velikim slovom i sadržavati samo slova!", "OK");
            return;
        }

        if (!Regex.IsMatch(LastNameEntry.Text, @"^[A-ZŠÐÈÆŽ][a-zšðèæž]+$"))
        {
            await DisplayAlert("Greška", "Prezime mora poèeti velikim slovom i sadržavati samo slova!", "OK");
            return;
        }

        // Telefon (samo cifre)
        if (!Regex.IsMatch(PhoneEntry.Text, @"^\d{6,15}$"))
        {
            await DisplayAlert("Greška", "Broj telefona smije sadržavati samo cifre (6-15)!", "OK");
            return;
        }

        // Kartica
        if (!Regex.IsMatch(CardNumberEntry.Text, @"^\d{16}$"))
        {
            await DisplayAlert("Greška", "Broj kartice mora imati 16 cifara!", "OK");
            return;
        }

        // CVV
        if (!Regex.IsMatch(CVVEntry.Text, @"^\d{3}$"))
        {
            await DisplayAlert("Greška", "CVV mora imati 3 cifre!", "OK");
            return;
        }

        // Datum isteka
        if (ExpiryPicker.Date < DateTime.Now)
        {
            await DisplayAlert("Greška", "Datum isteka kartice ne može biti u prošlosti!", "OK");
            return;
        }

        // Potvrda narudžbe
        await DisplayAlert("Narudžba", "Vaša narudžba je uspješno izvršena!", "OK");

        // Oèisti korpu
        CartService.Instance.Clear();

        // Reset polja
        FirstNameEntry.Text = LastNameEntry.Text = PhoneEntry.Text = AddressEntry.Text =
            CardNumberEntry.Text = CardNameEntry.Text = CVVEntry.Text = "";

        // Zatvori modal i vrati korisnika na Home tab
        await Navigation.PopModalAsync();
        await Shell.Current.GoToAsync("//home", true);
    }
}
