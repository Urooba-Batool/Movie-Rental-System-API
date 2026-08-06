using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Data
{
    public class MovieRentalSystemContext : DbContext
    {
        public MovieRentalSystemContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Admin" },
                new Roles { RoleId = 2, RoleName = "Employee" }
            );

            modelBuilder.Entity<CustomerStatus>().HasData(
                new CustomerStatus { Id = 1, StatusName = "Defaulter" },
                new CustomerStatus { Id = 2, StatusName = "Regular" },
                new CustomerStatus { Id = 3, StatusName = "VIP" },
                new CustomerStatus { Id = 4, StatusName = "Not Allowed" }
            );

            modelBuilder.Entity<MovieStatus>().HasData(
                new MovieStatus { Id = 1, StatusName = "Available" },
                new MovieStatus { Id = 2, StatusName = "Rented" },
                new MovieStatus { Id = 3, StatusName = "Reserved" },
                new MovieStatus { Id = 4, StatusName = "Not Available" }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users { UserId = 1, FirstName = "urooba", LastName = "batool", Email = "urooba@gmail.com", Password = "admin123", RoleId = 1 },
                new Users { UserId = 2, FirstName = "jia", LastName = "batool", Email = "jia@gmail.com", Password = "employee123", RoleId = 2 },
                new Users { UserId = 3, FirstName = "Ali", LastName = "Khan", Email = "ali@gmail.com", Password = "employee345", RoleId = 2 },
                new Users { UserId = 4, FirstName = "Ayesha", LastName = "Khan", Email = "ayesha@gmail.com", Password = "employee567", RoleId = 2 }
            );

            modelBuilder.Entity<Customers>().HasData(
                new Customers { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john@gmail.com", Age = 31, Address = "karachi", CustomerStatusId = 2 },
                new Customers { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@gmail.com", Age = 25, Address = "lahore", CustomerStatusId = 3 },
                new Customers { CustomerId = 3, FirstName = "Ali", LastName = "yawar", Email = "ali@gmail.com", Age = 28, Address = "islamabad", CustomerStatusId = 1 },
                new Customers { CustomerId = 4, FirstName = "Ayesha", LastName = "ali", Email = "ayesha@gmail.com", Age = 30, Address = "peshawar", CustomerStatusId = 4 },
                new Customers { CustomerId = 5, FirstName = "Ahmed", LastName = "khan", Email = "ahmed@gmail.com", Age = 27, Address = "quetta", CustomerStatusId = 2 }
            );

            modelBuilder.Entity<MovieGenres>().HasData(
                new MovieGenres { Id = 1, movieGenre = "Action" },
                new MovieGenres { Id = 2, movieGenre = "Comedy" },
                new MovieGenres { Id = 3, movieGenre = "Drama" },
                new MovieGenres { Id = 4, movieGenre = "Horror" },
                new MovieGenres { Id = 5, movieGenre = "Romance" },
                new MovieGenres { Id = 6, movieGenre = "Sci-Fi" },
                new MovieGenres { Id = 7, movieGenre = "Thriller" }
            );

            modelBuilder.Entity<Movies>().HasData(
                new Movies { Id = 1, MovieTitle = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010, RentalPrice = 6590, MovieGenreId = 6, MovieStatusId = 1 },
                new Movies { Id = 2, MovieTitle = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008, RentalPrice = 5990, MovieGenreId = 1, MovieStatusId = 2 },
                new Movies { Id = 3, MovieTitle = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994, RentalPrice = 4990, MovieGenreId = 1, MovieStatusId = 3 },
                new Movies { Id = 4, MovieTitle = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseYear = 1994, RentalPrice = 3990, MovieGenreId = 3, MovieStatusId = 4 },
                new Movies { Id = 5, MovieTitle = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972, RentalPrice = 6990, MovieGenreId = 3, MovieStatusId = 1 },
                new Movies { Id = 6, MovieTitle = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", ReleaseYear = 1999, RentalPrice = 5990, MovieGenreId = 6, MovieStatusId = 2 }
            );

            modelBuilder.Entity<BookingStatus>().HasData(
                new BookingStatus { Id = 1, StatusName = "Payment Pending" },
                new BookingStatus { Id = 2, StatusName = "Payement Confirmed" },
                new BookingStatus { Id = 3, StatusName = "Booking Cancelled" },
                new BookingStatus { Id = 4, StatusName = "Completed" }
            );

            modelBuilder.Entity<Bookings>().HasData(
                new Bookings { Id = 1, UserId = 2, CustomerId = 1, MovieId = 1, BookingDate = new DateTime(2026, 11, 5), ReturnDate = new DateTime(2026, 11, 7), BookingStatusId = 2 },
                new Bookings { Id = 2, UserId = 3, CustomerId = 2, MovieId = 2, BookingDate = new DateTime(2026, 12, 7), ReturnDate = new DateTime(2026, 12, 11), BookingStatusId = 1 },
                new Bookings { Id = 3, UserId = 2, CustomerId = 3, MovieId = 3, BookingDate = new DateTime(2026, 5, 1), ReturnDate = new DateTime(2026, 5, 2), BookingStatusId = 4 },
                new Bookings { Id = 4, UserId = 4, CustomerId = 4, MovieId = 4, BookingDate = new DateTime(2026, 6, 25), ReturnDate = new DateTime(2026, 6, 30), BookingStatusId = 3 },
                new Bookings { Id = 5, UserId = 3, CustomerId = 5, MovieId = 5, BookingDate = new DateTime(2026, 3, 28), ReturnDate = new DateTime(2026, 4, 3), BookingStatusId = 2 },
                new Bookings { Id = 6, UserId = 3, CustomerId = 1, MovieId = 6, BookingDate = new DateTime(2026, 4, 2), ReturnDate = new DateTime(2026, 4, 5), BookingStatusId = 1 },
                new Bookings { Id = 7, UserId = 1, CustomerId = 2, MovieId = 1, BookingDate = new DateTime(2026, 2, 7), ReturnDate = new DateTime(2026, 2, 9), BookingStatusId = 4 },
                new Bookings { Id = 8, UserId = 2, CustomerId = 3, MovieId = 2, BookingDate = new DateTime(2026, 3, 11), ReturnDate = new DateTime(2026, 3, 16), BookingStatusId = 3 }
            );

        }


            public DbSet<Users> Users { get; set; }
            public DbSet<Customers> Customers { get; set; }
            public DbSet<Movies> Movies { get; set; }
            public DbSet<Bookings> Bookings { get; set; }
            public DbSet<Roles> Roles { get; set; }
            public DbSet<CustomerStatus> CustomerStatus { get; set; }
            public DbSet<MovieStatus> MovieStatus { get; set; }
            public DbSet<BookingStatus> BookingStatus { get; set; }
            public DbSet<MovieGenres> MovieGenres { get; set; }
    
    }
}
