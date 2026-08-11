using MovieRentalSystem.Models;

namespace MovieRentalSystem.Services.Interfaces
{
    public interface IMovieGenreService
    {
        List<MovieGenres> GetMovieGenre();

        MovieGenres? GetMovieGenreById(int id);
        MovieGenres AddMovieGenre(MovieGenres movieGenre);
        MovieGenres? UpdateMovieGenre(int id, MovieGenres updateMovieGenre);
        MovieGenres? PatchMovieGenre(int id, MovieGenres updateMovieGenre);
    }
}
