using Projekatv2.Binding;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Projekatv2.Views;

namespace Projekatv2.Views;

public partial class FavouritesPage : ContentPage
{
    public FavouritesPage(Home home)
    {
        InitializeComponent();
        BindingContext = home; // koristi isti ViewModel kao MainPage
    }
}
