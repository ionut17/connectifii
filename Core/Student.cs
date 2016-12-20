using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public sealed class Student : Person
    {
        public Student()
        {
        }

        public Student(string registrationNumber, string firstName, string lastName, int year, string group,
            DateTime birthDate, ICollection<StudentCourse> courses)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            Group = group;
            BirthDate = birthDate;
            StudentCourses = courses;
        }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        [Required]
        [StringLength(2)]
        public string Group { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}