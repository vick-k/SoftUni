using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        [Comment("The game identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameTitleMaxLength)]
        [Comment("The game's title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GameDescriptionMaxLength)]
        [Comment("The game's description")]
        public string Description { get; set; } = null!;

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        [Comment("The game's publisher identifier")]
        public string PublisherId { get; set; } = null!;

        [Required]
        public virtual IdentityUser Publisher { get; set; } = null!;

        [Required]
        [Comment("The game's release date")]
        public DateTime ReleasedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        [Comment("The genre identifier")]
        public int GenreId { get; set; }

        [Required]
        public virtual Genre Genre { get; set; } = null!;

        public virtual ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
    }
}
