using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class User
    {
        [Key]
        [Column(TypeName = "VARCHAR(64)")]
        public Guid UserID { get; set; }

        public UserDetails UserDetails { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Fname { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Lname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailIsRequired")]
        [Column(TypeName = "VARCHAR(255)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(16)")]
        public string Salt { get; set; }

        public int UserType { get; set; }

        public List<Apartment> Apartments { get; set; }

        public List<UserRequirements> UserRequirements { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }
    }
}
