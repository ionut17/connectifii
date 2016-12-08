using System;
using System.Collections.Generic;

namespace Core
{
    public class Teacher : Person
    {
        public Teacher()
        {
        }

        public Teacher(string firstName, string lastName, DateTime birthDate, ICollection<Course> courses)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Courses = courses;
        }

        public virtual ICollection<Course> Courses { get; set; }
    }
}