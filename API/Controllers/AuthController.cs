using Domain;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace API.Controllers
{
    [Route("api/Auth")]
    [Produces("application/json")]
    public class AuthController : BaseController
    {
        public AuthController(DomainDispatcher domainDispatcher) : base(domainDispatcher)
        {
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var command = new LoginCommand(user.Email, user.Password);
            DomainDispatcher.ExecuteCommand(command);

            if (command.WasSuccesful)
                return Ok();
            else
                return BadRequest();
        }
    }
}