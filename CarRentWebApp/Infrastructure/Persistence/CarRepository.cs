using Application.Common.Interfaces.Persistence;
using Domain.Car;

namespace Infrastructure.Persistence
{
    public class CarRepository : ICarRepository
    {
        private static readonly List<Car> _cars = new();

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
    }
}
