using Domain.Common.Models;
using Domain.Reservation.ValueObjects;

namespace Domain.Reservation
{
    public class Reservation : AggregateRoot<ReservationId>
    {
        public Reservation(ReservationId id) : base(id)
        {
        }
    }
}
