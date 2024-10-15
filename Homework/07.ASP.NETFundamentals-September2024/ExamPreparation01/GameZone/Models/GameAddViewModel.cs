using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Models
{
    public class GameAddViewModel
    {
        [Required]
        [MinLength(GameTitleMinLength)]
        [MaxLength(GameTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(GameDescriptionMinLength)]
        [MaxLength(GameDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "The date is required.")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = $"The date should be in this format: {GameReleaseDateFormat}")]
        public string ReleasedOn { get; set; } = null!;

        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel>? Genres { get; set; }
    }
}
