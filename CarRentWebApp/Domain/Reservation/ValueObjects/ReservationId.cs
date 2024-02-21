using Domain.Common.Models;

namespace Domain.Reservation.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public int Value { get; }

        private ReservationId(int value)
        {
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
