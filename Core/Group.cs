using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Group : IEntity
    {
        public Group()
        {
        }

        public Group(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        [Required]
        [StringLength(2)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Guid Id { get; set; }
    }
}