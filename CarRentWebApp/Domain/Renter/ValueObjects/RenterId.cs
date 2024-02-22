using Domain.Common.Models;

namespace Domain.Renter.ValueObjects
{
    public sealed class RenterId : ValueObject
    {
        public Guid Value { get; }

        private RenterId(Guid value)
        {
            Value = value;
        }

        public static RenterId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
