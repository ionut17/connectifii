using System;

namespace Core
{
    public class StudentCourse
    {
        public StudentCourse()
        {
            
        }

        public StudentCourse(Student student, Course course)
        {
            Student = student;
            Course = course;

            StudentId = student.Id;
            CourseId = course.Id;
        }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public Nullable<Guid> StudentId { get; set; }
        public Nullable<Guid> CourseId { get; set; }
    }
}
