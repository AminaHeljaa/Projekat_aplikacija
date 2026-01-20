using Microsoft.Maui.Controls;
using Projekatv2.Models;
using Projekatv2.Services;

namespace Projekatv2.Views
{
    public partial class ProductDetailsPage : ContentPage
    {
        private Product _product;

        public ProductDetailsPage(Product product)
        {
            InitializeComponent();

            // Postavi BindingContext na odabrani proizvod
            _product = product;
            BindingContext = _product;
        }

        private void DodajBolan(object sender, EventArgs e)
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


        private async void OnBackTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//home");
        }
    }
    }
