﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class WaitingList
    {
        [Key]
        [Column(TypeName = "VARCHAR(64)")]
        public Guid WaitingID { get; set; }

        [Column(TypeName = "VARCHAR(64)")]
        public Guid? UserID { get; set; }

        public List<User> User { get; set; }

        [Column(TypeName = "VARCHAR(64)")]
        public Guid? ApartmentID { get; set; }

        public List<Apartment> Apartment { get; set; }

        [Timestamp()]
        public byte[] RowVersion { get; set; }
    }
}
