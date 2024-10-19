namespace DeskMarket.Models
{
    public class ProductAllViewModel
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Seller { get; set; } = null!;

        public bool IsSeller { get; set; }

        public bool HasBought { get; set; }
    }
}
