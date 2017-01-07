using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Group : IEntity
    {
        public Group()
        {
        }

        public Group(string name, int year)
        {
            Id = Guid.NewGuid();
            Name = name;
            Year = year;
        }

        [Required]
        [StringLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1)]
        [Range(0, 9)]
        public int Year { get; set; }

        public Guid Id { get; set; }
    }
}