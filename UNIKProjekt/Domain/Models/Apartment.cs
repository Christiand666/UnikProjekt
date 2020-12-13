using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Apartment
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR(250)")]

        public string ApartmentID { get; set; }

        [Column(TypeName = "VARCHAR(250)")]

        public string UserID { get; set; }
        public User User { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Zip { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int RoomCount { get; set; }

        [Required]
        public int SqrMeter { get; set; }

        [Required]
        public int Floors { get; set; }

        [Required]
        public double Rent { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public bool AllowPets { get; set; }

        [Required]
        public bool IsShareable { get; set; }

        [Required]
        public bool Balcony { get; set; }

        [Required]
        public bool IsApartment { get; set; }

        [Required]
        public bool IsHouse { get; set; }

        public bool IsRented { get; set; }

        /*[Timestamp()]
        public byte[] RowVersion { get; set; }*/
    }
}
