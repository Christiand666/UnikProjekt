using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IDB
    {
        DbSet<User> Users { get; set; }
        DbSet<Apartment> Apartments { get; set; }
        DbSet<UserDetails> UserDetails { get; set; }
        DbSet<WaitingList> WaitingList { get; set; }
        DbSet<ApartmentDemands> ApartmentDemands { get; set; }
        DbSet<ApplicantGoals> ApplicantGoals { get; set; }
        void Dispose(bool disposing);
        void SaveChanges();
        void Dispose();
    }
}
