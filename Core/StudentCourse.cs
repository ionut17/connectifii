using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class StudentCourse
    {
        [Key]
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Course Course { get; set; }

        [Key]
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Student Student { get; set; }
    }
}
