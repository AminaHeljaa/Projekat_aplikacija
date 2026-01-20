using Projekatv2.Binding;
using Microsoft.Maui.Controls;
using System;
using System.Linq; 
using Projekatv2.Views;
using Projekatv2.Binding;


namespace Projekatv2.Views;

public partial class CartPage : ContentPage
{
    private Korpa Binding => BindingContext as Korpa;

    public CartPage()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = new Korpa();

      
        UpdateEmptyState();

        // Automatski update kada se promijeni korpa
        Binding.Cart.CollectionChanged += (s, e) => UpdateEmptyState();
    }

    private void UpdateEmptyState()
    {
        bool isEmpty = Binding.Cart.Count == 0;
        CartCollection.IsVisible = !isEmpty;
        EmptyCart.IsVisible = isEmpty;
    }

    
    private void OnBackToHome(object sender, EventArgs e)
    {
        Shell.Current.CurrentItem.CurrentItem =
            Shell.Current.CurrentItem.Items
            .First(tab => tab.Title == "Home");
    }

    private async void PotvrdiBolan(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NarudzbaPage());
    }




  

}
