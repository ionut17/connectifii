using System;
using System.Collections.Generic;

namespace Core
{
    public class Teacher : Person
    {
        public Teacher()
        {
        }
        public Teacher(string firstName, string lastName, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        
        public Teacher(string firstName, string lastName, DateTime birthDate, Course course)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Course = course;
        }

        public Teacher(TeacherDto teacherDto)
        {
            Id = Guid.NewGuid();
            FirstName = teacherDto.FirstName;
            LastName = teacherDto.LastName;
            BirthDate = teacherDto.BirthDate;
        }

        public virtual Course Course { get; set; } = new Course();
    }
}