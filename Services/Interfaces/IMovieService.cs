using MovieRentalSystem.Models;


namespace MovieRentalSystem.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movies> GetMovies();

        Movies? GetMoviesById(int id);
        Movies AddMovies(Movies movies);
        Movies? UpdateMovies(int id, Movies updateMovies);
        Movies? PatchMovie(int id, Movies updateMovies);
    }
}
