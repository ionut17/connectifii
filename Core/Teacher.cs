using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class Teacher : Person
    {
        public Teacher()
        {
        }

        //util deocamdata doar pentru Dummy Data => posibil sa fie sters
        public Teacher(string firstName, string lastName, DateTime birthDate, ICollection<TeacherCourse> courses)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            TeacherCourse = courses;
        }

        public Teacher(TeacherDto teacherDto)
        {
            Id = Guid.NewGuid();
            FirstName = teacherDto.FirstName;
            LastName = teacherDto.LastName;
            BirthDate = teacherDto.BirthDate;
        }

        public ICollection<TeacherCourse> TeacherCourse { get; set; }
    }
}