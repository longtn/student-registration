using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.App.DTOs
{
    public class SubjectDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}