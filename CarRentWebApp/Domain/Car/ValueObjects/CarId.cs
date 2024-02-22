using Domain.Common.Models;
using Domain.Reservation.ValueObjects;

namespace Domain.Car.ValueObjects
{
    public sealed class CarId : ValueObject
    {
        public Guid Value { get; }

        private CarId(Guid value)
        {
            Value = value;
        }
        public static CarId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
