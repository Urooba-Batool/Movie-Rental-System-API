using MovieRentalSystem.Data;
using MovieRentalSystem.Services.Interfaces;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieRentalSystemContext _context;

        public MovieService(MovieRentalSystemContext context)
        {
            _context = context;
        }

        public List<Movies> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movies? GetMoviesById(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movies AddMovies(Movies addMovies)
        {
            _context.Movies.Add(addMovies);
            _context.SaveChanges();
            return addMovies;

        }

        public Movies? UpdateMovies(int id, Movies updateMovies)
        {
            var movies = _context.Movies.Find(id);
            if(movies == null )
            {
                return null;
            }

            movies.MovieTitle = updateMovies.MovieTitle;
            movies.Director = updateMovies.Director;
            movies.ReleaseYear = updateMovies.ReleaseYear;
            movies.RentalPrice = updateMovies.RentalPrice;
            movies.MovieGenreId = updateMovies.MovieGenreId;
            movies.MovieStatusId = updateMovies.MovieStatusId;
            _context.SaveChanges();
            return movies;
        }

        public Movies? PatchMovie(int id, Movies updateMovies)
        {
            var movies = _context.Movies.Find(id);
            if (movies == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(updateMovies.MovieTitle))
            {
                movies.MovieTitle = updateMovies.MovieTitle;
            }
            if (!string.IsNullOrEmpty(updateMovies.Director))
            {
                movies.Director = updateMovies.Director;
            }
            if (updateMovies.ReleaseYear != 0)
            {
                movies.ReleaseYear = updateMovies.ReleaseYear;
            }
            if (updateMovies.RentalPrice != 0)
            {
                movies.RentalPrice = updateMovies.RentalPrice;
            }
            if (updateMovies.MovieGenreId != 0)
            {
                movies.MovieGenreId = updateMovies.MovieGenreId;
            }
            if (updateMovies.MovieStatusId != 0)
            {
                movies.MovieStatusId = updateMovies.MovieStatusId;
            }
            _context.SaveChanges();

            return movies;
        }






    }
}
