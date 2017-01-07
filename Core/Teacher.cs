using System;

namespace Core
{
    public sealed class Teacher : Person
    {
        public Teacher()
        {
        }

        //util deocamdata doar pentru Dummy Data => posibil sa fie sters
        public Teacher(string firstName, string lastName, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Teacher(TeacherDto teacherDto)
        {
            Id = Guid.NewGuid();
            FirstName = teacherDto.FirstName;
            LastName = teacherDto.LastName;
            BirthDate = teacherDto.BirthDate;
        }
    }
}