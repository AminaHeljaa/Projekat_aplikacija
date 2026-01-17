using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Projekatv2.Models;
using Projekatv2.Services;
using Projekatv2.Views;
using Projekatv2.Binding;
namespace Projekatv2.Binding
{
    public class Home : BindableObject
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> FavoriteProducts { get; set; }

        private ObservableCollection<Product> _filteredProducts;
        public ObservableCollection<Product> FilteredProducts
        {
            get => _filteredProducts;
            set
            {
                _filteredProducts = value;
                OnPropertyChanged();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                FilterProducts();
            }
        }

        public ObservableCollection<string> FeaturedImages { get; set; }

        public ICommand ToggleFavoriteCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand SelectCategoryCommand { get; }
        public ICommand OpenProductDetailsCommand { get; }

        public Home()
        {
            // SVI PROIZVODI
            Products = new ObservableCollection<Product>
            {
              new Product {
    Name="Dorina poffertjes",
    Description="Mekani mini poffertjes prekriveni bogatom Dorina čokoladom koja se savršeno topi na toplim palačinkama. Idealni za sve ljubitelje klasične čokolade i intenzivnog okusa.",
    Price=5.5,
    Image="dorina1.png",
    Category="Holandski",
    Rating = 4.7
},
                new Product { Name="Bueno poffertjes", Description="Bueno grande čokolada", Price=6.0, Image="bueno1.png", Category="Holandski" },
                new Product { Name="Voćni zalogaj poffertjes", Description="Svježina voća", Price=6.0, Image="vocnizalogaj1.jpg", Category="Holandski" },
                new Product { Name="Slatki zalogaj poffertjes", Description="Sa dodacima banane i šlaga", Price=5.5, Image="slatkizalogaj1.jpg", Category="Holandski" },
                new Product { Name="Rafaelo poffertjes", Description="Za ljubitelje kokosa i bijele čokolade", Price=7.0, Image="rafaelo1.jpg", Category="Holandski" },
                new Product { Name="Kinder poffertjes", Description="Okus mliječne čokolade", Price=5.0, Image="p1.jpg", Category="Holandski" },
                new Product { Name="Oreo poffertjes", Description="Mrvice orea satkane sa čoko okusom", Price=6.0, Image="oreo1.jpg", Category="Holandski" },
                new Product { Name="Jafa poffertjes", Description="Jafa čokolada sa kremom", Price=6.0, Image="jafa.jpg", Category="Holandski" },

                new Product { Name="Ferero palačinak", Description="Ukusna mliječna čokolada sa ferero kuglicama", Price=7.5, Image="palacinaferero.jpg", Category="Palacinci" },
                new Product { Name="King palačinak", Description="Ukusna za ljubitelje king proizvoda", Price=6.5, Image="palacinakking.jpg", Category="Palacinci" },
                new Product { Name="Jabuka palačinak", Description="Jabuka daje svježu notu za one koji vole ovu voćnu kombinaciju", Price=5.5, Image="palacinakjabuka.jpg", Category="Palacinci" },
                new Product { Name="Plazma palačinak", Description="Keks i čokolada idelana kombinacija", Price=4.5, Image="palacinakplazma", Category="Palacinci" },
                new Product { Name="Palačinak sushi", Description="Shusi na slatki način", Price=6.5, Image="palacinaksushi.jpg", Category="Palacinci" },
                new Product { Name="Malina palačinak", Description="Voćna kombinacija i slatki svijet", Price=5.5, Image="palacinakmalina.jpg", Category="Palacinci" },

               new Product { Name="Sprite", Description="Svjež i ukusan", Price=2.5, Image="sprite.png", Category="Pića" },
               new Product { Name="Coca Cola", Description="Svjež i ukusan", Price=2.5, Image="kola.png", Category="Pića" },
               new Product { Name="Coca Cola Zero", Description="Svjež i ukusan", Price=2.5, Image="kolaz.png", Category="Pića" },
               new Product { Name="Fanta", Description="Svjež i ukusan", Price=2.5, Image="fanta.png", Category="Pića" },


                new Product { Name="Wafl Bueno", Description="Odličan okus bueno čokolade", Price=5.0, Image="waflbueno.jpg", Category="Wafl" },
                new Product { Name="Wafl Čoko", Description="Čokolada i odličan ukus", Price=7.0, Image="waflcoko.jpg", Category="Wafl" },
                new Product { Name="Wafl Ferero", Description="Najbolja čokolada sa jedinstvenim okusom", Price=8.0, Image="waflferero.png", Category="Wafl" },
                new Product { Name="Wafl Pistacija", Description="Pistacija i ukusna čokolada", Price=10.0, Image="waflpistacija.jpg", Category="Wafl" },
                new Product { Name="Wafl Plazma", Description="Za posebne prilike", Price=9.0, Image="waflplazma.png", Category="Wafl" },

            };

            FilteredProducts = new ObservableCollection<Product>(Products);

            // FAVORITI (horizontalni skrol)
            FavoriteProducts = new ObservableCollection<Product>
            {
               new Product { Name="Pistacija Palačinak", Description="Sočna palačinka prekrivena kremastom pistacija pastom i posuta hrskavim komadićima pistacija. Savršen balans između blagih orašastih nota i slatkog okusa, idealno za sve ljubitelje pistacija.", Price=2.5, Image="pistacija.jpg", Category="Palacinci", Rating=4.6 },
                new Product { Name="Rafaelo Palačinak", Image="rafaelo1.jpg", Price=3 },
                new Product { Name="Voćni Palačinak", Image="palacinakmalina.png", Price=3.5 },
                new Product { Name="Jafa Palačinak", Image="jafa.png", Price=3 }
            };

            // SLIDER SLIKE
            FeaturedImages = new ObservableCollection<string>
            {
                "palacinak2.jpg",
                "palacinak.jpg",
                "logo2.png"
            };

            // ❤️ FAVORITE
            ToggleFavoriteCommand = new Command<Product>(product =>
            {
                if (product == null) return;

                product.IsFavorite = !product.IsFavorite;

                if (product.IsFavorite)
                {
                    if (!FavoriteProducts.Contains(product))
                        FavoriteProducts.Add(product);
                }
                else
                {
                    if (FavoriteProducts.Contains(product))
                        FavoriteProducts.Remove(product);
                }
            });

            // 🛒 DODAJ U KORPU (PREKO CartService)
            AddToCartCommand = new Command<Product>(product =>
            {
                if (product == null) return;

                CartService.Instance.AddToCart(product);

                // PREBACI NA CART TAB
                var tabBar = Shell.Current.Items.FirstOrDefault() as TabBar;
                var cartTab = tabBar?.Items.FirstOrDefault(t => t.Title == "Cart");

                if (cartTab != null)
                    Shell.Current.CurrentItem = cartTab;
            });


            // 📂 FILTER PO KATEGORIJI
            SelectCategoryCommand = new Command<string>(category =>
            {
                SelectedCategory = category;
            });

            OpenProductDetailsCommand = new Command<Product>(product =>
            {
                // kasnije detalji
            });
        }

        private void FilterProducts()
        {
            if (string.IsNullOrEmpty(SelectedCategory))
                FilteredProducts = new ObservableCollection<Product>(Products);
            else
                FilteredProducts = new ObservableCollection<Product>(
                    Products.Where(p => p.Category == SelectedCategory));
        }
    }
}
