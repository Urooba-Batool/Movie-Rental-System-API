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
        private readonly MovieRentalSystemContext _contect;

        public MovieStatusController(MovieRentalSystemContext context)
        {
            _contect = context;
        }

        [HttpGet]
        public ActionResult GetMovieStatus()
        {
            var movieStatus = _contect.MovieStatus.ToList();
            return Ok(movieStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieStatusById(int id)
        {
            var movieStatus = _contect.MovieStatus.Find(id);            
            if (movieStatus == null)
            {
                return NotFound();
            }
            return Ok(movieStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovieStatus(int id, MovieStatus updatemoviestatus)
        {
            var movieStatus = _contect.MovieStatus.Find(id);
            if (id == null)
            {
                return BadRequest();
            }
            if (movieStatus == null)
            {
                return NotFound();
            }
            movieStatus.StatusName = updatemoviestatus.StatusName;
            _contect.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateMovieStatus(MovieStatus newmoviestatus)
        {
            _contect.MovieStatus.Add(newmoviestatus);
            _contect.SaveChanges();
            return CreatedAtAction(nameof(GetMovieStatusById), new { id = newmoviestatus.Id }, newmoviestatus);
        }

        [HttpPatch]
        public ActionResult PatchMovieStatus(int id, MovieStatus patchmoviestatus)
        {
            var movieStatus = _contect.MovieStatus.Find(id);
            if (id == null)
            {
                return BadRequest();
            }
            if (movieStatus == null)
            {
                return NotFound();
            }
            movieStatus.StatusName = patchmoviestatus.StatusName;
            _contect.SaveChanges();
            return NoContent();
        }

        
    }
}
