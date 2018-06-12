using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DomainDispatcher DomainDispatcher;

        public BaseController(DomainDispatcher domainDispatcher)
        {
            DomainDispatcher = domainDispatcher;
        }
    }
}