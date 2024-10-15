using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        [Comment("The genre identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        [Comment("The genre's name")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
