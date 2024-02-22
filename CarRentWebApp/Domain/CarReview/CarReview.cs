using Domain.CarReview.ValueObjects;
using Domain.Common.Models;
using Domain.Renter.ValueObjects;
using Domain.Reservation.ValueObjects;

namespace Domain.CarReview
{
    public sealed class CarReview : AggregateRoot<CarReviewId>
    {
        public ReservationId ReservationId { get; }
        public RenterId RenterId { get; }

        private CarReview(
            CarReviewId carReviewId,
            ReservationId reservationId,
            RenterId renterId) : base(carReviewId)
        {
            ReservationId = reservationId;
            RenterId = renterId;
        }

        public static CarReview Create(
            ReservationId reservationId,
            RenterId renterId)
        {
            return new(
                CarReviewId.CreateUnique(),
                reservationId,
                renterId);
        }
    }
}
