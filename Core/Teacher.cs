﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public Teacher(TeacherDto teacherDto)
        {
            Id = Guid.NewGuid();
            FirstName = teacherDto.FirstName;
            LastName = teacherDto.LastName;
            BirthDate = teacherDto.BirthDate;
        }

        [JsonIgnore]
        public virtual ICollection<TeacherCourse> StudentCourses { get; set; } = new List<TeacherCourse>();
    }
}