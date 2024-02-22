using Domain.Common.Models;
using Domain.Renter.ValueObjects;
using Domain.RenterRating.ValueObjects;
using Domain.Reservation.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Renter
{
    public sealed class Renter : AggregateRoot<RenterId>
    {
        public UserId UserId { get; }
        private readonly List<ReservationId> _reservationIds = new();
        private readonly List<RenterRatingId> _renterRatingIds = new();

        public Renter(
            RenterId renterId,
            UserId userId)
            : base(renterId)
        {
            UserId = userId;
        }

        public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.ToList();
        public IReadOnlyList<RenterRatingId> RenterRatingIds => _renterRatingIds.ToList();
    }
}
