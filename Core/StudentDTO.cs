using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class StudentDto
    {
        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}