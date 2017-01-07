using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public sealed class Student : Person
    {
        public Student()
        {
        }

        public Student(string registrationNumber, string firstName, string lastName, Group group,
            DateTime birthDate)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Group = group;
            BirthDate = birthDate;
        }

        [Required]
        public string RegistrationNumber { get; set; }

        public Group Group { get; set; }
    }
}