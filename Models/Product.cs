namespace Projekatv2.Models
{
    public class Product
    {
        public int Id { get; set; }  // <--- dodaj ovo
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public bool IsFavorite { get; set; }
        public double Rating { get; set; }   // npr 4.5
        public int Reviews { get; set; }
    }
}
