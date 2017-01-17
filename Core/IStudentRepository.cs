using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core

{
    public interface IStudentRepository<T> : IRepository<T> where T : class, IEntity
    {
        Student GetByRegistrationNumber(string registrationNumber);
        ICollection<Student> GetByIds(ICollection<Guid?> ids);
        ICollection<Guid?> GetStudentCourses(string registrationNumber);
        ICollection<Guid?> GetStudentCourses(Guid id);
    }
}
