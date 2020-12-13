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
        public DbSet<UserRequirements> UserRequirements { get; set; }
        public DbSet<WaitingList> WaitingList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(i => i.User)
                .HasForeignKey<UserDetails>(b => b.UserID).IsRequired();*/
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}

