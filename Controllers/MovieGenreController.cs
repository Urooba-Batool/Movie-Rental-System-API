using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        private readonly IMovieGenreService _movieGenreService;

        public MovieGenreController(IMovieGenreService movieGenreService)
        {
            _movieGenreService = movieGenreService;
        }

        [HttpGet]
        public ActionResult GetMovieGenres()
        {
            var movieGenres = _movieGenreService.GetMovieGenre();
            return Ok(movieGenres);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieGenreById(int id)
        {
            var movieGenres = _movieGenreService.GetMovieGenreById(id);
            return Ok(movieGenres);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovieGnre(int id, MovieGenres updateMovieGenre)
        {
            var movieGenres = _movieGenreService.UpdateMovieGenre(id, updateMovieGenre);
            return Ok(movieGenres);
        }

        [HttpPost]
        public ActionResult AddMovieGenre(MovieGenres addmovieGenre)
        {
            var movieGenres = _movieGenreService.AddMovieGenre(addmovieGenre);
            return CreatedAtAction(nameof(GetMovieGenreById), new { id = addmovieGenre.Id }, addmovieGenre);
        }

        [HttpPatch]
        public ActionResult PatchMovieGenre(int id, MovieGenres patchMovieGenre)
        {
            var movieGenres = _movieGenreService.PatchMovieGenre(id, patchMovieGenre);
            return Ok(movieGenres);
        }
    }
}
