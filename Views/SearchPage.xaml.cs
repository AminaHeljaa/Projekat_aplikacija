using Projekatv2.Models;
using Projekatv2.Services;

namespace Projekatv2.Views;

public partial class SearchPage : ContentPage
{
    private List<Product> _allProducts;

    public SearchPage(IEnumerable<Product> products)
    {
        InitializeComponent();

        _allProducts = products.ToList();
        ProductsCollection.ItemsSource = _allProducts;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue?.ToLower();

        if (string.IsNullOrWhiteSpace(text))
        {
            ProductsCollection.ItemsSource = _allProducts;
            return;
        }

        ProductsCollection.ItemsSource = _allProducts.Where(p =>
            p.Name.ToLower().Contains(text) ||
            p.Category.ToLower().Contains(text)
        ).ToList();
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

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}
