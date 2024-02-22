using Domain.Common.Models;

namespace Domain.CarReview.ValueObjects
{
    public sealed class CarReviewId : ValueObject
    {
        public Guid Value { get; }

        private CarReviewId(Guid value)
        {
            Value = value;
        }

        public static CarReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
