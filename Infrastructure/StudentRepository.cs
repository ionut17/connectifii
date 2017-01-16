using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class StudentRepository : AbstractRepository<Student>
    {
        public ICollection<Student> GetByIds(ICollection<Guid?> ids)
        {
            return Context.Students.Where(s => ids.Contains(s.Id)).ToList();
        }

        public Student GetByRegistrationNumber(string registrationNumber)
        {
            return
            // return Context.Students.Include(s => s.StudentCourses).Include(s => s.Group).FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
                Context.Students.Include(s => s.Group)
                    .FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
        }

        public ICollection<Guid?> GetStudentCourses(string registrationNumber)
        {
            ICollection<Guid?> coursesIDs =
                Context.StudentCourses.Where(sc => sc.StudentRegistrationNumber.Equals(registrationNumber))
                    .Select(sc => sc.CourseId)
                    .ToList();
            return coursesIDs;
        }

        public ICollection<Guid?> GetStudentCourses(Guid id)
        {
            ICollection<Guid?> coursesIDs =
                Context.StudentCourses.Where(sc => sc.StudentId.Equals(id))
                    .Select(sc => sc.CourseId)
                    .ToList();
            return coursesIDs;
        }
    }
}