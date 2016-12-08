using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public abstract class Person : IEntity
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}