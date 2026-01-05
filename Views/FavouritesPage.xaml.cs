using Projekatv2.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Projekatv2.Views;

namespace Projekatv2.Views;

public partial class FavouritesPage : ContentPage
{
    public FavouritesPage(HomeViewModel homeViewModel)
    {
        InitializeComponent();
        BindingContext = homeViewModel; // koristi isti ViewModel kao MainPage
    }
}
