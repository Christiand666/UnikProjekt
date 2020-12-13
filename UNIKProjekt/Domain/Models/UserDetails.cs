using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class UserDetails
    {
        [Key]
        [Column(TypeName = "VARCHAR(64)")]
        public string DetailsID { get; set; }

        [Column(TypeName = "VARCHAR(64)")]
        public string UserID { get; set; }
        public User User { get; set; }

        
        [Required]
        [Column(TypeName = "VARCHAR(32)")]
        public string Phone { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        public string Country { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        public bool Animals { get; set; }

        public string AnimalType { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }





       

    }
}
