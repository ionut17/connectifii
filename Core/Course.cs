using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Course : IEntity
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

        public Course(string title, int year, List<Student> students, List<Teacher> teachers)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            Students = students;
            Teachers = teachers;
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

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}