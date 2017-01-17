using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface ITeacherRepository<T> : IRepository<T> where T : class, IEntity
    {
        ICollection<Teacher> GetByIds(ICollection<Guid?> ids);

        ICollection<Guid?> GetTeacherCourses(Guid id);
    }
}
