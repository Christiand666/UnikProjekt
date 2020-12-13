using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class UserRequirements
    {
        [Key]
        [Column(TypeName = "VARCHAR(64)")]
        public string RequirementID { get; set; }

        [Column(TypeName = "VARCHAR(64)")]
        public string UserID { get; set; }

        public User User { get; set; }

        public int? RoomCount { get; set; }

        public double? Rent { get; set; }

        public int? SqrMeter { get; set; }

        public string Zip { get; set; } // Stored as JSON array/list

        public bool? Shareable { get; set; }

        public int? Floors { get; set; }

        public bool? IsHouse { get; set; }
        public bool? IsApartment { get; set; }
        public bool? Balcony { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }

    }
}
