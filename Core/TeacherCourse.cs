using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TeacherCourse
    {
        [Required]
        public Guid TeacherId { get; set; }

        [Required]
        public Teacher Teacher { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}