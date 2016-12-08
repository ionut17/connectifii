using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public interface IEntity
    {
        [Key]
        [Required]
        Guid Id { get; set; }
    }
}