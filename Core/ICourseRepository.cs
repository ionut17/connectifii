using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface ICourseRepository<T> : IRepository<T> where T : class, IEntity
    {
        ICollection<Course> GetByIds(ICollection<Guid?> ids);

        ICollection<Guid?> GetCourseStudents(Guid id);
        ICollection<Guid?> GetCourseTeachers(Guid id);
    }
}
