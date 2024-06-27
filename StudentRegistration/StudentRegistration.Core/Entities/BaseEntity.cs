using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Core.Entities
{
    public class BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
