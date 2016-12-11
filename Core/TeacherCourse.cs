using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class TeacherCourse
    {
        [Key]
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Course Course { get; set; }

        [Key]
        [Required]
        public Guid TeacherId { get; set; }

        [Required]
        public Teacher Teacher { get; set; }
    }
}