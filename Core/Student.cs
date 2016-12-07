using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Student : IEntity
    {
        public Student(string firstName)
        {
            FirstName = firstName;
        }

        [Key]
        [StringLength(16)]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(1)]
        public int Year { get; set; }

        [Required]
        [StringLength(2)]
        public string Group { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}