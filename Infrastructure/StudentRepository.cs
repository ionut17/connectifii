using System.Linq;
using Core;

namespace Infrastructure
{
    public class StudentRepository : AbstractRepository<Student>
    {
        public Student GetByRegistrationNumber(string registrationNumber)
        {
            return Context.Students.FirstOrDefault(s => s.RegistrationNumber.Equals(registrationNumber));
        }
    }
}