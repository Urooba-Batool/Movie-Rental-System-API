using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalSystem.Data;
using MovieRentalSystem.Models;
using MovieRentalSystem.Services.Interfaces;

namespace MovieRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStatusController : ControllerBase
    {
        private readonly IMovieStatusService _movieStatusService;

        public MovieStatusController(IMovieStatusService movieStatusService)
        {
            _movieStatusService = movieStatusService;
        }

        [HttpGet]
        public ActionResult GetMovieStatus()
        {
            var movieStatus = _movieStatusService.GetMovieStatus();
            return Ok(movieStatus);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieStatusById(int id)
        {
            var movieStatus = _movieStatusService.GetMovieStatusById(id);
            if (movieStatus == null)
            {
                return NotFound();
            }
            return Ok(movieStatus);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovieStatus(int id, MovieStatus updatemoviestatus)
        {
            var movieStatus = _movieStatusService.UpdateMovieStatus(id, updatemoviestatus);
            if (movieStatus == null)
            {
                return NotFound();
            }
            
            return Ok(movieStatus);
        }

        [HttpPost]
        public ActionResult AddMovieStatus(MovieStatus addMovieStatus)
        {
            _movieStatusService.AddMovieStatus(addMovieStatus);
            return CreatedAtAction(nameof(GetMovieStatusById), new { id = addMovieStatus.Id }, addMovieStatus);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchMovieStatus(int id, MovieStatus updateMovieStatus)
        {
            var movieStatus = _movieStatusService.PatchMovieStatus(id, updateMovieStatus);

            return Ok(movieStatus);
        }

        
    }
}
