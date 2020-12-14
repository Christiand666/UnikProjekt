using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class ApartmentDemands
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        public string DemandsID { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        public int RoomCount { get; set; }

        [Required]
        public int SqrMeter { get; set; }

        [Required]
        public double Rent { get; set; }

        [Required]
        public bool AllowPets { get; set; }

        [Required]
        public bool IsShareable { get; set; }

        [Required]
        public bool HasBalcony { get; set; }

        [Required]
        public bool IsApartment { get; set; }

        [Required]
        public bool IsHouse { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(64)")]
        public string UserID { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }
    }
}
