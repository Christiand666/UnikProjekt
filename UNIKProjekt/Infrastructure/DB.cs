using Domain.Models;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DB : DbContext, IDB
    {
        public DB(DbContextOptions<DB> options)
                : base(options)
        {

        }

        void IDB.SaveChanges()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("DB Concurrency error.");
            }
        }

        /* 
            Initializing tables from Database
        */
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
       
        public DbSet<WaitingList> WaitingList { get; set; }
        public DbSet<ApartmentDemands> ApartmentDemands { get; set; }
        public DbSet<ApplicantGoals> ApplicantGoals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Apartment>().

            /*modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(i => i.User)
                .HasForeignKey<UserDetails>(b => b.UserID).IsRequired();*/

            modelBuilder.Entity<Apartment>()
                .HasOne(p => p.User)
                .WithMany(b => b.Apartments)
                .HasForeignKey(p => p.ApartmentID)
                .HasConstraintName("FK_Apartments_LandlordID")
                .IsRequired(true);

            modelBuilder.Entity<Apartment>()
                .HasOne(p => p.User)
                .WithMany(b => b.Apartments)
                .HasForeignKey(p => p.ApartmentID)
                .HasConstraintName("FK_Apartments_UserID")
                .IsRequired(false);

            modelBuilder.Entity<Apartment>()
                .HasOne(p => p.ApplicantGoals)
                .WithMany(b => b.Apartments)
                .HasForeignKey(p => p.ApplicantGoalsID)
                .HasConstraintName("FK_Apartments_ApplicantGoals_ApplicantGoalsID")
                .IsRequired(false);

            // FK_Apartments_LandlordID
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}

