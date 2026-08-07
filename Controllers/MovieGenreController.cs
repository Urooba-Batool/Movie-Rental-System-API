using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public MovieGenreController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetMovieGenres()
        { 
            var movieGenres = _context.MovieGenres.ToList();
            return Ok(movieGenres);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieGnereById(int id)
        {
            var movieGenres = _context.MovieGenres.Find(id);
            if(movieGenres == null)
            {
                return NotFound();
            }
            return Ok(movieGenres);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovieGnre(int id, MovieGenres updateMovieGenre)
        {
            var movieGenres = _context.MovieGenres.Find(id);
            if(movieGenres == null)
            {
                return NotFound();
            }
            movieGenres.movieGenre = updateMovieGenre.movieGenre;
            _context.SaveChanges();
            return Ok(movieGenres);
        }

        [HttpPost]
        public ActionResult AddMovieGenre(MovieGenres addmovieGenre)
        {
            _context.MovieGenres.Add(addmovieGenre);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieGnereById), new { id = addmovieGenre.Id }, addmovieGenre);
        }

        [HttpPatch]
        public ActionResult PatchMovieGenre(int id, MovieGenres patchMovieGenre)
        {
            var movieGenres = _context.MovieGenres.Find(id);
            if(movieGenres == null)
            {
                return NotFound();
            }
            movieGenres.movieGenre = patchMovieGenre.movieGenre;
            _context.SaveChanges();
            return Ok(movieGenres);
        }
    }
}
