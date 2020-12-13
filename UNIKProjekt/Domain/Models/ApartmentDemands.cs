using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class ApartmentDemands
    {
        [Key]
        [Required]
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
        public bool Shareable { get; set; }

        [Required]
        public bool Balcony { get; set; }

        [Required]
        public bool IsApartment { get; set; }

        [Required]
        public bool IsHouse { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Guid UserID { get; set; }
    }
}
