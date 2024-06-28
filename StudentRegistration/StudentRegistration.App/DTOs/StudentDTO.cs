using StudentRegistration.App.Enums;
using StudentRegistration.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.App.DTOs
{
    public class StudentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string NRIC { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public GenderEnum Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Birthday { get; set; } = DateTime.Now;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? AvailableDate { get; set; } = null;

        public DateTime CreatedDate { get; set; }

        public List<int> SelectedSubjects { get; set; } = new List<int>();


        public int Age
        {
            get
            {
                return Birthday.GetAge();
            }
        }

        public int NumberOfSubjects
        {
            get
            {
                return SelectedSubjects.Count;
            }
        }
    }
}