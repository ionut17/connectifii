using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class CourseDto
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
    }
}