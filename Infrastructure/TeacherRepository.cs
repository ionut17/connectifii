using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class TeacherRepository : AbstractRepository<Teacher>
    {
        public ICollection<Teacher> GetByIds(ICollection<Guid?> ids)
        {
            return Context.Teachers.Where(s => ids.Contains(s.Id)).ToList();
        }

        public ICollection<Guid?> GetTeacherCourses(Guid id)
        {
            ICollection<Guid?> coursesIDs =
                Context.TeacherCourses.Where(tc => tc.TeacherId.Equals(id))
                    .Select(tc => tc.CourseId)
                    .ToList();
            return coursesIDs;
        }
    }
}