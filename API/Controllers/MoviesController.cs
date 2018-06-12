using Domain;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/movies")]
    [Produces("application/json")]
    public class MoviesController : BaseController
    {
        public MoviesController(DomainDispatcher domain) : base(domain)
        {
        }

        [HttpGet()]
        public IActionResult GetMovies()
        {
            var movies = DomainDispatcher.ExecuteQuery(new GetAllMoviesQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = DomainDispatcher.ExecuteQuery(new GetMovieQuery(id));

            if (movie == null)
                return NotFound();
            
            return Ok(movie);
        }
    }
}