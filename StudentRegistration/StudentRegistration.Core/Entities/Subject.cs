using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Core.Entities
{
    public class Subject : BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        public virtual IEnumerable<StudentSubject> Students { get; set; }
    }
}
