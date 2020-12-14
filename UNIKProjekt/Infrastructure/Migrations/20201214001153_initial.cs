using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantGoals",
                columns: table => new
                {
                    GoalsID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Animals = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantGoals", x => x.GoalsID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Fname = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Lname = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Salt = table.Column<string>(type: "VARCHAR(16)", nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentDemands",
                columns: table => new
                {
                    DemandsID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    RoomCount = table.Column<int>(nullable: false),
                    SqrMeter = table.Column<int>(nullable: false),
                    Rent = table.Column<double>(nullable: false),
                    AllowPets = table.Column<bool>(nullable: false),
                    IsShareable = table.Column<bool>(nullable: false),
                    HasBalcony = table.Column<bool>(nullable: false),
                    IsApartment = table.Column<bool>(nullable: false),
                    IsHouse = table.Column<bool>(nullable: false),
                    UserID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentDemands", x => x.DemandsID);
                    table.ForeignKey(
                        name: "FK_ApartmentDemands_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    LandlordID = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    UserID = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    City = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    RoomCount = table.Column<int>(nullable: false),
                    SqrMeter = table.Column<int>(nullable: false),
                    Floors = table.Column<int>(nullable: false),
                    Rent = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    AllowPets = table.Column<bool>(nullable: false),
                    IsShareable = table.Column<bool>(nullable: false),
                    HasBalcony = table.Column<bool>(nullable: false),
                    IsApartment = table.Column<bool>(nullable: false),
                    IsHouse = table.Column<bool>(nullable: false),
                    ApplicantGoalsID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    IsRented = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentID);
                    table.ForeignKey(
                        name: "FK_Apartments_ApplicantGoals_ApplicantGoalsID",
                        column: x => x.ApplicantGoalsID,
                        principalTable: "ApplicantGoals",
                        principalColumn: "GoalsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    DetailsID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    UserID = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    Animals = table.Column<bool>(nullable: false),
                    AnimalType = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.DetailsID);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaitingList",
                columns: table => new
                {
                    WaitingID = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    UserID = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    ApartmentID = table.Column<string>(type: "VARCHAR(64)", nullable: true),
                    ApplicationScore = table.Column<double>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingList", x => x.WaitingID);
                    table.ForeignKey(
                        name: "FK_WaitingList_Apartments_ApartmentID",
                        column: x => x.ApartmentID,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaitingList_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentDemands_UserID",
                table: "ApartmentDemands",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApplicantGoalsID",
                table: "Apartments",
                column: "ApplicantGoalsID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserID",
                table: "Apartments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserID",
                table: "UserDetails",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaitingList_ApartmentID",
                table: "WaitingList",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingList_UserID",
                table: "WaitingList",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentDemands");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "WaitingList");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "ApplicantGoals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
