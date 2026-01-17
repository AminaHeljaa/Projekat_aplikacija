using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Projekatv2.Models;
using Projekatv2.Services;

namespace Projekatv2.Binding
{
    public class Korpa : BindableObject
    {
        public ObservableCollection<CartItem> Cart { get; }

        public ICommand IncreaseCommand { get; }
        public ICommand DecreaseCommand { get; }
        public ICommand RemoveCommand { get; }

        public Korpa()
        {
            Cart = CartService.Instance.Cart;
            Cart.CollectionChanged += (s, e) => OnPropertyChanged(nameof(TotalPrice));

            IncreaseCommand = new Command<CartItem>(item =>
            {
                CartService.Instance.Increase(item);
                OnPropertyChanged(nameof(TotalPrice));
            });

            DecreaseCommand = new Command<CartItem>(item =>
            {
                CartService.Instance.Decrease(item);
                OnPropertyChanged(nameof(TotalPrice));
            });

            RemoveCommand = new Command<CartItem>(item =>
            {
                CartService.Instance.Remove(item);
                OnPropertyChanged(nameof(TotalPrice));
            });
        }

        public decimal TotalPrice => Cart.Sum(i => i.Price * i.Quantity);
    }
}
