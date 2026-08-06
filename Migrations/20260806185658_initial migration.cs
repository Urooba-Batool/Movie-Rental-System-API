using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieRentalSystem.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookingStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieGenre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<double>(type: "float", nullable: false),
                    MovieGenreId = table.Column<int>(type: "int", nullable: false),
                    MovieStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "BookingStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Payment Pending" },
                    { 2, "Payement Confirmed" },
                    { 3, "Booking Cancelled" },
                    { 4, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "BookingStatusId", "CustomerId", "MovieId", "ReturnDate", "TotalDays", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 2, new DateTime(2026, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, new DateTime(2026, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 3, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 3, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 4, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 4, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 5, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 5, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 6, new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 6, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 7, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 1, new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 },
                    { 8, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 2, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CustomerStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Defaulter" },
                    { 2, "Regular" },
                    { 3, "VIP" },
                    { 4, "Not Allowed" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Age", "CustomerStatusId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "karachi", 31, 2, "john@gmail.com", "John", "Doe" },
                    { 2, "lahore", 25, 3, "jane@gmail.com", "Jane", "Smith" },
                    { 3, "islamabad", 28, 1, "ali@gmail.com", "Ali", "yawar" },
                    { 4, "peshawar", 30, 4, "ayesha@gmail.com", "Ayesha", "ali" },
                    { 5, "quetta", 27, 2, "ahmed@gmail.com", "Ahmed", "khan" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "movieGenre" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Romance" },
                    { 6, "Sci-Fi" },
                    { 7, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "MovieStatus",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "Rented" },
                    { 3, "Reserved" },
                    { 4, "Not Available" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "MovieGenreId", "MovieStatusId", "MovieTitle", "ReleaseYear", "RentalPrice" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan", 6, 1, "Inception", 2010, 6590.0 },
                    { 2, "Christopher Nolan", 1, 2, "The Dark Knight", 2008, 5990.0 },
                    { 3, "Quentin Tarantino", 1, 3, "Pulp Fiction", 1994, 4990.0 },
                    { 4, "Frank Darabont", 3, 4, "The Shawshank Redemption", 1994, 3990.0 },
                    { 5, "Francis Ford Coppola", 3, 1, "The Godfather", 1972, 6990.0 },
                    { 6, "Lana Wachowski, Lilly Wachowski", 6, 2, "The Matrix", 1999, 5990.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "urooba@gmail.com", "urooba", "batool", "admin123", 1 },
                    { 2, "jia@gmail.com", "jia", "batool", "employee123", 2 },
                    { 3, "ali@gmail.com", "Ali", "Khan", "employee345", 2 },
                    { 4, "ayesha@gmail.com", "Ayesha", "Khan", "employee567", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerStatus");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieStatus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
