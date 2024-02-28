using Contracts.Cars;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class CarsController : ApiController
    {
        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(new List<string>());
        }

        [HttpPost]
        public IActionResult CreateCar(CreateCarRequest request)
        {
            return Ok(request);
        }
    }
}
