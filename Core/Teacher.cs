using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class Teacher : Person
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

        public ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}