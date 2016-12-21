using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StudentRepository : AbstractRepository<Student>
    {
        public Student GetByRegistrationNumber(string registrationNumber)
        {
            return Context.Students.Include(s => s.StudentCourses).FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
           // return Context.Students.Include(s => s.StudentCourses).Include(s => s.Group).FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
        }
    }
}