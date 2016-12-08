using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Course : IEntity
    {
        public Course(string title, int year, ICollection<Teacher> teachers)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            Teachers = teachers;
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}