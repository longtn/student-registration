using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Core.Entities
{
    public class Student : BaseEntity
    {
        [Required, StringLength(10)]
        public string NRIC { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public DateTime? AvailableDate { get; set; }

        public virtual IEnumerable<StudentSubject> Subjects { get; set; }
    }
}
