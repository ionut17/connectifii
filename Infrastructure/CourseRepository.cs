using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class CourseRepository : AbstractRepository<Course>, ICourseRepository<Course>
    {
        public ICollection<Course> GetByIds(ICollection<Guid?> ids)
        {
            return Context.Courses.Where(c => ids.Contains(c.Id)).ToList();
        }

        public ICollection<Guid?> GetCourseStudents(Guid id)
        {
            ICollection<Guid?> studentsIDs =
                Context.StudentCourses.Where(sc => sc.CourseId.Equals(id))
                    .Select(sc => sc.StudentId)
                    .ToList();
            return studentsIDs;
        }

        public ICollection<Guid?> GetCourseTeachers(Guid id)
        {
            ICollection<Guid?> teachersIDs =
                Context.TeacherCourses.Where(tc => tc.CourseId.Equals(id))
                    .Select(tc => tc.TeacherId)
                    .ToList();
            return teachersIDs;
        }
    }
}