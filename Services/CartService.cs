using System.Collections.ObjectModel;
using System.Linq;
using Projekatv2.Models;

namespace Projekatv2.Services
{
    public class CartService
    {
        private static CartService _instance;
        public static CartService Instance => _instance ??= new CartService();

        public ObservableCollection<CartItem> Cart { get; }
            = new ObservableCollection<CartItem>();

        private CartService() { }

        // ➕ DODAJ U KORPU
        public void AddToCart(Product product)
        {
            var existing = Cart.FirstOrDefault(x => x.Name == product.Name);

            if (existing != null)
            {
                existing.Quantity++; // Quantity mora imati OnPropertyChanged
            }
            else
            {
                Cart.Add(new CartItem
                {
                    Name = product.Name,
                    Category = product.Category,
                    Price = (decimal)product.Price, // 🔥 OVO RJEŠAVA GREŠKU
                    Image = product.Image,
                    Quantity = 1
                });

            }
        }

        // ➕ POVEĆAJ KOLIČINU
        public void Increase(CartItem item)
        {
            if (item == null) return;
            item.Quantity++;
        }

        // ➖ SMANJI KOLIČINU
        public void Decrease(CartItem item)
        {
            if (item == null) return;

            if (item.Quantity > 1)
                item.Quantity--;
            else
                Cart.Remove(item); // ako padne na 0 → briše se
        }

        // 🗑 OBRIŠI PROIZVOD
        public void Remove(CartItem item)
        {
            if (item != null && Cart.Contains(item))
                Cart.Remove(item);
        }

        // 🧹 OČISTI KORPU
        public void Clear()
        {
            Cart.Clear();
        }

        // 💰 UKUPNA CIJENA
        public decimal TotalPrice =>
            Cart.Sum(item => item.Price * item.Quantity);
    }
}
