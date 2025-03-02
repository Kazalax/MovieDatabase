using Microsoft.AspNetCore.Mvc;
using Movies.Api.Interfaces;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase 
    {
        private readonly IGenreManager genreManager;
        public GenresController(IGenreManager genreManager)
    {
        this.genreManager = genreManager;
    }

        [HttpGet]
        public IEnumerable<string>GetGenres()
        {
            return genreManager.GetAllGenres();
        }
    }
}
