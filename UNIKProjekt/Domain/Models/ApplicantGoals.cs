using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ApplicantGoals
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        public string GoalsID { get; set; }
        public List<Apartment> Apartments { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public bool Animals { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }
    }
}
