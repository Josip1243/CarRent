using Application.Cars.Commands;
using Contracts.Cars;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class CarsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public CarsController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(new List<string>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarRequest request, Guid ownerId)
        {
            var command = _mapper.Map<AddCarCommand>((request, ownerId));
            var createCarResult = await _sender.Send(command);

            return createCarResult.Match(
                car => Ok(_mapper.Map<CarResponse>(car)),
                errors => Problem(errors)
            );
        }
    }
}
