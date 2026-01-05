using System.ComponentModel;

public class CartItem : INotifyPropertyChanged
{
    private int _quantity;

    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; } // CIJENA PO KOMADU

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity == value) return;
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Total));
        }
    }

    public decimal Total => Price * Quantity;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
