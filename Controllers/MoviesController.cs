using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // [Authorize (Roles = "Admin")]
        [HttpGet]
        public  ActionResult GetMovies()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult GetMoviesById(int id)
        {
            var movies = _movieService.GetMoviesById(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovies(int id, Movies updateMovies)
        {
            var movies = _movieService.UpdateMovies(id, updateMovies);
            if(movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public ActionResult AddMovies(Movies addMovies)
        {
            var movies = _movieService.AddMovies(addMovies);

            return CreatedAtAction(nameof(GetMoviesById), new { id = addMovies.Id }, addMovies);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchMovies(int id, Movies updateMovies)
            {
            var movies = _movieService.PatchMovie(id, updateMovies);

            return Ok(movies);
        }
    }
}
