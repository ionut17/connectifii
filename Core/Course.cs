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
        public Course(string title, int year, ICollection<TeacherCourse> teachers)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            TeacherCourse = teachers;
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        public virtual ICollection<TeacherCourse> TeacherCourse { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}