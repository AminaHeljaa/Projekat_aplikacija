
using Projekatv2.Views;
using Projekatv2.ViewModel;
using Projekatv2.Models;
using Projekatv2.Services;
namespace Projekatv2;

public partial class MainPage : ContentPage
{
    private HomeViewModel ViewModel => BindingContext as HomeViewModel;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }

    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Product selectedProduct)
        {
            await Shell.Current.GoToAsync(nameof(ProductDetailsPage),
                new Dictionary<string, object>
                {
                    { "Product", selectedProduct }
                });

            ((CollectionView)sender).SelectedItem = null;
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

        // Dodaj ili ukloni iz FavoriteProducts liste
        if (product.IsFavorite)
        {
            if (!ViewModel.FavoriteProducts.Contains(product))
                ViewModel.FavoriteProducts.Add(product);
        }
        else
        {
            if (ViewModel.FavoriteProducts.Contains(product))
                ViewModel.FavoriteProducts.Remove(product);
        }
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

    private void OnSearch_Clicked_1(object sender, EventArgs e)
    {

    }
}
