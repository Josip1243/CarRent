using Application.Common.Interfaces.Persistence;
using Domain.Car;
using Domain.Owner.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Cars.Commands
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, ErrorOr<Car>>
    {
        private readonly ICarRepository _carRepository;

        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<ErrorOr<Car>> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Create car
            var car = Car.Create(
                OwnerId.Create(request.OwnerId),
                request.Brand,
                request.Model,
                request.ManufacturedDate);

            // Persist car
            _carRepository.AddCar(car);

            // return car
            return car;
        }
    }
}
