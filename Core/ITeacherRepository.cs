using System;
using System.Collections.Generic;

namespace Core
{
    public interface ITeacherRepository<T> : IRepository<T> where T : class, IEntity
    {
        ICollection<Teacher> GetByIds(ICollection<Guid?> ids);

        ICollection<Guid?> GetTeacherCourses(Guid id);
    }
}