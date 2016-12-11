using System;
using System.Collections.Generic;

namespace Core
{
    public class Teacher : Person
    {
        public Teacher()
        {
        }

        public Teacher(string firstName, string lastName, DateTime birthDate, ICollection<TeacherCourse> courses)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            TeacherCourse = courses;
        }

        public virtual ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}