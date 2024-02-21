using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
