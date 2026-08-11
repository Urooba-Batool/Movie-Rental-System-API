using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IMovieStatusService
    {
        List<MovieStatus> GetMovieStatus();
        MovieStatus? GetMovieStatusById(int id);
        MovieStatus? UpdateMovieStatus(int id, MovieStatus updateMovieStatus);
        MovieStatus? PatchMovieStatus(int id, MovieStatus updateMovieStatus);
        MovieStatus AddMovieStatus(MovieStatus addMovieStatus);
    }
}
