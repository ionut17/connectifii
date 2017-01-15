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
            StudentRegistrationNumber = student.RegistrationNumber;
        }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public Guid? StudentId { get; set; }
        public Guid? CourseId { get; set; }
        public string StudentRegistrationNumber { get; set; }
    }
}