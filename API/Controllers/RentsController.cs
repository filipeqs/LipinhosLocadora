using Domain;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/movies/{movieId}/rents")]
    public class RentsController : BaseController
    {
        public RentsController(DomainDispatcher domainDispatcher) : base(domainDispatcher)
        {
        }

        [HttpGet()]
        public IActionResult GetRentsForMovie(int movieId)
        {
            var rents = DomainDispatcher.ExecuteQuery(new GetRentsForMovieQuery(movieId));

            if (rents == null)
            {
                return NotFound();
            }

            return Ok(rents);
        }
    }
}