using Domain;
using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

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

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovie(int id)
        {
            var movie = DomainDispatcher.ExecuteQuery(new GetMovieQuery(id));

            if (movie == null)
                return NotFound();
            
            return Ok(movie);
        }

        [HttpPost("create")]
        public IActionResult CreateMovie([FromBody]Movie movie)
        {
            if (movie == null)
                return NotFound();

            var command = new CreateMovieCommand(movie);
            DomainDispatcher.ExecuteCommand(command);

            if (command.WasSuccesful)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditMovie(int id, [FromBody]Movie movie)
        {
            var command = new EditMovieCommand(movie);
            DomainDispatcher.ExecuteCommand(command);

            if (command.WasSuccesful)
                return Ok(movie);
            else
                return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var command = new DeleteMovieCommand(id);
            DomainDispatcher.ExecuteCommand(command);

            if (command.WasSuccesful)
                return NoContent();
            else
                return BadRequest();
        }
    }
}