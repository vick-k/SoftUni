using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.ValidationConstants;

namespace SeminarHub.Models
{
    public class SeminarAddViewModel
    {
        [Required]
        [MinLength(SeminarTopicMinLength)]
        [MaxLength(SeminarTopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [MinLength(SeminarLecturerMinLength)]
        [MaxLength(SeminarLecturerMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [MinLength(SeminarDetailsMinLength)]
        [MaxLength(SeminarDetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}$", ErrorMessage = $"The date should be in this format: {DateTimeFormat}")]
        public string DateAndTime { get; set; } = null!;

        [Range(SeminarDurationMin, SeminarDurationMax)]
        public int Duration { get; set; }

        public string? OrganizerId { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
