namespace BACKEND_PROJEKT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string Image { get; set; } = string.Empty;
        public string? Category { get; set; }
        public int Rating { get; set; } = 5;
    }
}
