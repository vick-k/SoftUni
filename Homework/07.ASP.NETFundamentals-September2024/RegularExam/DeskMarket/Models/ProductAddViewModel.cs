using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models
{
    public class ProductAddViewModel
    {
        [Required]
        [DisplayName(ProductDisplayName)]
        [MinLength(ProductNameMinLength, ErrorMessage = "The product name length should be at least {1} characters.")]
        [MaxLength(ProductNameMaxLength, ErrorMessage = "The product name length cannot be more than {1} characters.")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue, ErrorMessage = "The price should be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength, ErrorMessage = "The description length should be at least {1} characters.")]
        [MaxLength(ProductDescriptionMaxLength, ErrorMessage = "The description length cannot be more than {1} characters.")]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength, ErrorMessage = "The Image URL length cannot be more than {1} characters.")]
        public string? ImageUrl { get; set; }

        [Required]
        [DisplayName(ProductDateDisplayName)]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = $"The date should be in this format: {ProductDateTimeFormat}")]
        public string AddedOn { get; set; } = null!;

        public string? SellerId { get; set; }

        [DisplayName(CategoryDisplayName)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
