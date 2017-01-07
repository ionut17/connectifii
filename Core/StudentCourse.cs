using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class StudentCourse
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public virtual Course Course { get; set; }
    }
}