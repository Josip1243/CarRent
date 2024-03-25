using Domain.Car;
using ErrorOr;
using MediatR;

namespace Application.Cars.Commands
{
    public record AddCarCommand(
        Guid OwnerId,
        string Brand,
        string Model,
        DateOnly ManufacturedDate) : IRequest<ErrorOr<Car>>;
}
