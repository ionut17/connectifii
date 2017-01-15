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

        public Course(string title, int year, ICollection<Student> students, ICollection<Teacher> teachers)
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            foreach (var student in students)
                StudentCourses.Add(new StudentCourse(student, this));
            foreach (var teacher in teachers)
                TeacherCourses.Add(new TeacherCourse(teacher, this));
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

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; } = new List<TeacherCourse>();

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}