using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public MoviesController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  ActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("{id}")]
        public ActionResult GetMoviesById(int id)
        {
            var movies = _context.Movies.Find(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovies(int id, Movies updateMovies)
        {
            var movies = _context.Movies.Find(id);
            if(movies == null)
            {
                return NotFound();
            }
            movies.MovieTitle = updateMovies.MovieTitle;
            movies.Director = updateMovies.Director;
            movies.ReleaseYear = updateMovies.ReleaseYear;
            movies.RentalPrice = updateMovies.RentalPrice;
            movies.MovieGenreId = updateMovies.MovieGenreId;
            movies.MovieStatusId = updateMovies.MovieStatusId;
            _context.SaveChanges();
            return Ok(movies);
        }

        [HttpPost]
        public ActionResult AddMovies(Movies addMovies)
        {
            _context.Movies.Add(addMovies);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMoviesById), new { id = addMovies.Id }, addMovies);
        }

        [HttpPatch]
        public ActionResult PatchMovies(int id, Movies updateMovies)
            {
            var movies = _context.Movies.Find(id);
            if (movies == null)
            {
                return NotFound();
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
            return Ok(movies);
        }
    }
}
