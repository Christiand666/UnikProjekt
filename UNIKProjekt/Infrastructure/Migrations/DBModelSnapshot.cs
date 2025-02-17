﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DB))]
    partial class DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Apartment", b =>
                {
                    b.Property<string>("ApartmentID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<bool>("AllowPets")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ApplicantGoalsID")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Floors")
                        .HasColumnType("int");

                    b.Property<bool>("HasBalcony")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsApartment")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHouse")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRented")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShareable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LandlordID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<double>("Rent")
                        .HasColumnType("double");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.Property<int>("SqrMeter")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("ApartmentID");

                    b.HasIndex("ApplicantGoalsID");

                    b.HasIndex("UserID");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Domain.Models.ApartmentDemands", b =>
                {
                    b.Property<string>("DemandsID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<bool>("AllowPets")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HasBalcony")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsApartment")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHouse")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsShareable")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Rent")
                        .HasColumnType("double");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.Property<int>("SqrMeter")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("DemandsID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("ApartmentDemands");
                });

            modelBuilder.Entity("Domain.Models.ApplicantGoals", b =>
                {
                    b.Property<string>("GoalsID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<bool>("Animals")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.HasKey("GoalsID");

                    b.ToTable("ApplicantGoals");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("VARCHAR(16)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.UserDetails", b =>
                {
                    b.Property<string>("DetailsID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("AnimalType")
                        .HasColumnType("text");

                    b.Property<bool>("Animals")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("UserID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("DetailsID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Domain.Models.WaitingList", b =>
                {
                    b.Property<string>("WaitingID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("ApartmentID")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<double>("ApplicationScore")
                        .HasColumnType("double");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("UserID")
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("WaitingID");

                    b.HasIndex("ApartmentID");

                    b.HasIndex("UserID");

                    b.ToTable("WaitingList");
                });

            modelBuilder.Entity("Domain.Models.Apartment", b =>
                {
                    b.HasOne("Domain.Models.ApplicantGoals", "ApplicantGoals")
                        .WithMany()
                        .HasForeignKey("ApplicantGoalsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Apartments")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Domain.Models.ApartmentDemands", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne("ApartmentDemands")
                        .HasForeignKey("Domain.Models.ApartmentDemands", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.UserDetails", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("Domain.Models.UserDetails", "UserID");
                });

            modelBuilder.Entity("Domain.Models.WaitingList", b =>
                {
                    b.HasOne("Domain.Models.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentID");

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
