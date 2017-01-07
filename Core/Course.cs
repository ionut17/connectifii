using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public sealed class Course : IEntity
    {
        public Course()
        {
        }

        public Course(string title, int year)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
        }

        public Course(CourseDto courseDto)
        {
            Id = Guid.NewGuid();
            Title = courseDto.Title;
            Year = courseDto.Year;
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}