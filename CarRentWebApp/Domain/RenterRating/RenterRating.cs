using Domain.Common.Models;
using Domain.Owner.ValueObjects;
using Domain.RenterRating.ValueObjects;
using Domain.Reservation.ValueObjects;

namespace Domain.RenterRating
{
    public sealed class RenterRating : AggregateRoot<RenterRatingId>
    {
        public ReservationId ReservationId { get; }
        public OwnerId OwnerId { get; }

        private RenterRating(
            RenterRatingId renterRatingId,
            ReservationId reservationId,
            OwnerId ownerId)
            : base(renterRatingId)
        {
            ReservationId = reservationId;
            OwnerId = ownerId;
        }

        public static RenterRating Create(ReservationId reservationId, OwnerId ownerId)
        {
            return new(
                RenterRatingId.CreateUnique(),
                reservationId,
                ownerId);
        }
    }
}
