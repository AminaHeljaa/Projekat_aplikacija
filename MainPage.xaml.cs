
using Projekatv2.Views;
using Projekatv2.Binding;
using Microsoft.Maui.Controls;
using Projekatv2.Models;
using Projekatv2.Services;
namespace Projekatv2;

public partial class MainPage : ContentPage
{
    private Home Binding=> BindingContext as Home;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new Home();
    }

    private async void OnProductTapped(object sender, EventArgs e)
    {
        // Dobij proizvod vezan za frame
        if (sender is Frame frame && frame.BindingContext is Product tappedProduct)
        {
            await Navigation.PushAsync(new ProductDetailsPage(tappedProduct));
        }
    }


    // Funkcija koja vraća sliku srca ovisno o statusu favorita
    private string GetHeartImage(bool isFavorite)
    {
        return isFavorite ? "zutosrce.png" : "heart.png";
    }

    private void OnHeartClicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        if (button == null) return;

        var product = button.BindingContext as Product;
        if (product == null) return;

        // Toggle favorite
        product.IsFavorite = !product.IsFavorite;

        // Postavi sliku koristeći funkciju
        button.Source = GetHeartImage(product.IsFavorite);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var product = button?.BindingContext as Product;
        if (product == null) return;

        CartService.Instance.AddToCart(product);

        // PREBACI NA CART TAB
        Shell.Current.CurrentItem.CurrentItem =
            Shell.Current.CurrentItem.Items
            .First(tab => tab.Title == "Cart");
    }


    private void ImageButton_Clicked(object sender, EventArgs e)
    {
     
    

    }

    private async void OnSearch_Clicked_1(object sender, EventArgs e)
    {
        var home = Binding;
        if (home == null) return;

        await Navigation.PushAsync(new SearchPage(home.Products));
    }
}
