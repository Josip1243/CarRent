using Domain.Car;

namespace Application.Common.Interfaces.Persistence
{
    public interface ICarRepository
    {
        void AddCar(Car car);
    }
}
