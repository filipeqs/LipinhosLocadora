using API.Models;
using Domain;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(AuthModel authModel)
        {
            var command = new LoginCommand(authModel.Email, authModel.Password);
            DomainDispatcher.ExecuteCommand(command);

            if (command.WasSuccesful)
                return Ok();
            else
                return BadRequest();
        }
    }
}