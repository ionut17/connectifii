using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class TeacherCourse
    {
        public TeacherCourse()
        {
            
        }

        public TeacherCourse(Teacher teacher, Course course)
        {
            Teacher = teacher;
            Course = course;

            TeacherId = teacher.Id;
            CourseId = course.Id;
        }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }

        public Nullable<Guid> TeacherId { get; set; }
        public Nullable<Guid> CourseId { get; set; }
    }
}
