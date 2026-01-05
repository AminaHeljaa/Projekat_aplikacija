using Projekatv2.ViewModel;
using Microsoft.Maui.Controls;
using System;
using System.Linq;


namespace Projekatv2.Views;

public partial class CartPage : ContentPage
{
    private CartViewModel ViewModel => BindingContext as CartViewModel;

    public CartPage()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        // Postavi BindingContext
        BindingContext = new CartViewModel();

        // Provjeri da li je korpa prazna
        UpdateEmptyState();

        // Automatski update kada se promijeni korpa
        ViewModel.Cart.CollectionChanged += (s, e) => UpdateEmptyState();
    }

    private void UpdateEmptyState()
    {
        bool isEmpty = ViewModel.Cart.Count == 0;
        CartCollection.IsVisible = !isEmpty;
        EmptyCart.IsVisible = isEmpty;
    }

    // Dugme "Naruèi još" ? vraæa na HomePage
    private void OnBackToHome(object sender, EventArgs e)
    {
        Shell.Current.CurrentItem.CurrentItem =
            Shell.Current.CurrentItem.Items
            .First(tab => tab.Title == "Home");
    }




    // Dugme "Izvrši narudžbu"
    private async void OnPlaceOrder(object sender, EventArgs e)
    {
        if (ViewModel.Cart.Count == 0)
        {
            await DisplayAlert("Korpa", "Vaša korpa je prazna!", "OK");
            return;
        }

        // Ovdje možeš dodati logiku za spremanje narudžbe u bazu

        await DisplayAlert("Narudžba", "Vaša narudžba je izvršena!", "OK");

        // Oèisti korpu
        ViewModel.Cart.Clear();
    }
}
