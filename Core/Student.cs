﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Student : Person
    {
        public Student()
        {
        }

        public Student(string registrationNumber, string firstName, string lastName, int year, Group group,
            DateTime birthDate)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            Group = group;
            BirthDate = birthDate;
        }

        public Student(string registrationNumber, string firstName, string lastName, int year, Group group,
            DateTime birthDate, Course course)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            Group = group;
            BirthDate = birthDate;
            Course = course;
        }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        public Group Group { get; set; }

        public virtual Course Course { get; set; } = new Course();
    }
}