using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class ApplicantGoals
    {
        [Key]
        [Required]
        public string GoalsID { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public bool Animals { get; set; }
    }
}
