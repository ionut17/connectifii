using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Student : Person
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

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}