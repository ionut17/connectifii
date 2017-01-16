using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class GroupDto
    {
        [Required]
        [StringLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(0, 9)]
        public int Year { get; set; }
    }
}