using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public sealed class Course : IEntity
    {
        public Course()
        {
        }

        public Course(string title, int year, ICollection<TeacherCourse> teachers, ICollection<StudentCourse> students)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            TeacherCourse = teachers;
            StudentCourse = students;
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        public ICollection<TeacherCourse> TeacherCourse { get; set; } = new List<TeacherCourse>();
        public ICollection<StudentCourse> StudentCourse { get; set; } = new List<StudentCourse>();

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}