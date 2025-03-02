
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;
using Movies.Api.Models;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieManager movieManager;
        public MovieController(IMovieManager movieManager)
        {
            this.movieManager = movieManager;
        }


        [HttpGet]
        public IEnumerable<MovieDto> GetMovies([FromQuery] MovieFilterDto movieFilter)
        {
            return movieManager.GetAllMovies(movieFilter);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovie(uint movieId)
        {
            ExtendedMovieDto? movie = movieManager.GetMovie(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movie)
        {
            MovieDto createdMovie = movieManager.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { movieId = createdMovie.MovieId }, createdMovie);
        }

        [HttpPut("{movieId}")]
        public IActionResult EditMovie(uint movieId, [FromBody] MovieDto movie)
        {
            MovieDto? updatedMovie = movieManager.UpdateMovie(movieId, movie);

            if (updatedMovie is null)
                return NotFound();

            return Ok(updatedMovie);
        }
        [HttpDelete("{movieId}")]
        public IActionResult DeleteMovie(uint movieId)
        {
            MovieDto? deletedMovie = movieManager.DeleteMovie(movieId);

            if (deletedMovie is null)
                return NotFound();

            return Ok(deletedMovie);

        }
    }
}
