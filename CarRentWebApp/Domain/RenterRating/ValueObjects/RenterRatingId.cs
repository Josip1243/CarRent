using Domain.Car.ValueObjects;
using Domain.Common.Models;

namespace Domain.RenterRating.ValueObjects
{
    public sealed class RenterRatingId : ValueObject
    {
        public Guid Value { get; }

        private RenterRatingId(Guid value)
        {
            Value = value;
        }
        public static RenterRatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
