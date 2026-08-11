using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class MovieGenreService : IMovieGenreService
    {
        private readonly MovieRentalSystemContext _context;

        public MovieGenreService(MovieRentalSystemContext context)
        {
            _context = context;
        }
        public List<MovieGenres> GetMovieGenre()
        {
            return _context.MovieGenres.ToList();
        }

        public MovieGenres? GetMovieGenreById(int id)
        {
            return _context.MovieGenres.Find(id);
        }
        public MovieGenres AddMovieGenre(MovieGenres addMovieGenre)
        {
            _context.MovieGenres.Add(addMovieGenre);
            _context.SaveChanges();
            return addMovieGenre;

        }
        public MovieGenres? UpdateMovieGenre(int id, MovieGenres updateMovieGenre)
        {
            var movieGenres = _context.MovieGenres.Find(id);
            if (movieGenres == null)
            {
                return null;
            }
            movieGenres.movieGenre = updateMovieGenre.movieGenre;
            _context.SaveChanges();
            return movieGenres;
        }
        public MovieGenres? PatchMovieGenre(int id, MovieGenres updateMovieGenre)
        {
            var movieGenres = _context.MovieGenres.Find(id);
            if (movieGenres == null)
            {
                return null;
            }
            movieGenres.movieGenre = updateMovieGenre.movieGenre;
            _context.SaveChanges();
            return movieGenres;
        }
    }
}
