using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Services
{
    public class MovieStatusService : IMovieStatusService
    {
        private readonly MovieRentalSystemContext _context;

        public MovieStatusService(MovieRentalSystemContext context)
        {
            _context = context;
        }
        public List<MovieStatus> GetMovieStatus()
        {
            return _context.MovieStatus.ToList();
        }
        public MovieStatus? GetMovieStatusById(int id)
        {
            return _context.MovieStatus.Find(id);
        }
        public MovieStatus? UpdateMovieStatus(int id, MovieStatus updateMovieStatus)
        {
            var movieStatus = _context.MovieStatus.Find(id);
            movieStatus.StatusName = updateMovieStatus.StatusName;
            _context.SaveChanges();
            return movieStatus;
        }
        public MovieStatus? PatchMovieStatus(int id, MovieStatus updateMovieStatus)
        {
            var movieStatus = _context.MovieStatus.Find(id);

            if (movieStatus == null)
            {
                return null;
            }
            movieStatus.StatusName = updateMovieStatus.StatusName;
            _context.SaveChanges();
            return movieStatus;
        }
        public MovieStatus AddMovieStatus(MovieStatus addMovieStatus)
        {
            _context.MovieStatus.Add(addMovieStatus);
            _context.SaveChanges();
            return addMovieStatus;
        }
    }
}
