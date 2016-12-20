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

        public Student(string registrationNumber, string firstName, string lastName, int year, Group group,
            DateTime birthDate, ICollection<Course> courses)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            Group = group;
            BirthDate = birthDate;
            Courses = courses;
        }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        [Required]
        public Group Group { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}