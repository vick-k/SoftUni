﻿namespace SeminarHub.Models
{
    public class SeminarAllViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = null!;

        public string Lecturer { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string DateAndTime { get; set; } = null!;

        public string Organizer { get; set; } = null!;
    }
}
