using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        [Comment("Product identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The name of the product")]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Comment("The description of the product")]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The price of the product")]
        public decimal Price { get; set; }

        [Comment("The URL of the image for the product")]
        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Seller identifier")]
        [ForeignKey(nameof(Seller))]
        public string SellerId { get; set; } = null!;

        public virtual IdentityUser Seller { get; set; } = null!;

        [Required]
        [Comment("The date when the product is added")]
        public DateTime AddedOn { get; set; }

        [Required]
        [Comment("Category identifier")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        [Comment("Flag for soft delete")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }
}
