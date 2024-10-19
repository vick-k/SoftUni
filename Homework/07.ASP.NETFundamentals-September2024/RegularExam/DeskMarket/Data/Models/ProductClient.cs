using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Required]
        [Comment("Product identifier")]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

        [Required]
        [Comment("Client identifier")]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = null!;

        public virtual IdentityUser Client { get; set; } = null!;
    }
}
