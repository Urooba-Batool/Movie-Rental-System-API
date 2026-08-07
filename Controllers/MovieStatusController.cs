using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStatusController : ControllerBase
    {
        private readonly MovieRentalSystemContext _context;

        public MovieStatusController(MovieRentalSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetMovieStatus()
        {
            var movieStatus = _context.MovieStatus.ToList();
            return Ok(movieStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieStatusById(int id)
        {
            var movieStatus = _context.MovieStatus.Find(id);            
            if (movieStatus == null)
            {
                return NotFound();
            }
            return Ok(movieStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovieStatus(int id, MovieStatus updatemoviestatus)
        {
            var movieStatus = _context.MovieStatus.Find(id);
            if (movieStatus == null)
            {
                return NotFound();
            }
            movieStatus.StatusName = updatemoviestatus.StatusName;
            _context.SaveChanges();
            return Ok(movieStatus);
        }

        [HttpPost]
        public ActionResult CreateMovieStatus(MovieStatus newmoviestatus)
        {
            _context.MovieStatus.Add(newmoviestatus);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieStatusById), new { id = newmoviestatus.Id }, newmoviestatus);
        }

        [HttpPatch]
        public ActionResult PatchMovieStatus(int id, MovieStatus patchmoviestatus)
        {
            var movieStatus = _context.MovieStatus.Find(id);
            if (id == null)
            {
                return BadRequest();
            }
            if (movieStatus == null)
            {
                return NotFound();
            }
            movieStatus.StatusName = patchmoviestatus.StatusName;
            _context.SaveChanges();
            return NoContent();
        }

        
    }
}
