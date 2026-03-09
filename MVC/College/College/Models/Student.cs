using System;
using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Course { get; set; }

        public string Department { get; set; }

        public int Year { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        public string? PhotoPath { get; set; }
        public string? RollNumber { get; set; }

        public DateTime AppliedDate { get; set; }
    }
}