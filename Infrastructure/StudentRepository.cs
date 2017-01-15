using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudentRepository : AbstractRepository<Student>
    {
        public Student GetByRegistrationNumber(string registrationNumber)
        {
            return Context.Students.FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
        }

        public ICollection<Course> GetStudentCourses(string registrationNumber)
        {
            ICollection<Nullable<Guid>> coursesIDs =
                Context.StudentCourses.Where(sc => sc.StudentRegistrationNumber.Equals(registrationNumber))
                    .Select(sc => sc.CourseId)
                    .ToList();
            return Context.Courses.Where(c => coursesIDs.Contains(c.Id)).ToList();
        }
    }
}