using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class StudentCourse
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}