using Domain.Common.Models;

namespace Domain.Owner.ValueObjects
{
    public class OwnerId : ValueObject
    {
        public Guid Value { get; }

        private OwnerId(Guid value)
        {
            Value = value;
        }

        public static OwnerId Create(Guid value)
        {
            return new OwnerId(value);
        }

        public static OwnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
