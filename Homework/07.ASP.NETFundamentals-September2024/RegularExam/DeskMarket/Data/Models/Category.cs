using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{
	public class Category
	{
		[Key]
		[Comment("Category identifier")]
		public int Id { get; set; }

		[Required]
		[Comment("The name of the category")]
		[MaxLength(CategoryNameMaxLength)]
		public string Name { get; set; } = null!;

		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
