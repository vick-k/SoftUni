﻿using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.ValidationConstants;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
