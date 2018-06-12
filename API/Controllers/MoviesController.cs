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

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = DomainDispatcher.ExecuteQuery(new GelAllMoviesQuery());
            return Ok(movies);
        }
    }
}