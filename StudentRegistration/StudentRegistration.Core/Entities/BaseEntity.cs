using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Core.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
