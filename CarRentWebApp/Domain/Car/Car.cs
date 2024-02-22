using Domain.Car.ValueObjects;
using Domain.CarReview.ValueObjects;
using Domain.Common.Models;
using Domain.Owner.ValueObjects;
using Domain.Reservation.ValueObjects;

namespace Domain.Car
{
    public sealed class Car : AggregateRoot<CarId>
    {
        public OwnerId OwnerId { get; }

        public string Brand { get; }
        public string Model { get; }
        public DateOnly ManufacturedDate { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }

        private readonly List<CarReviewId> _carReviewIds = new();
        private readonly List<ReservationId> _reservationIds = new();
        public IReadOnlyList<CarReviewId> CarReviewIds => _carReviewIds.ToList();
        public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.ToList();

        private Car(
            CarId carId,
            OwnerId ownerId,
            string brand,
            string model,
            DateOnly manufacturedDate,
            DateTime created,
            DateTime updated)
            :base(carId)
        {
            OwnerId = ownerId;
            Brand = brand;
            Model = model;
            ManufacturedDate = manufacturedDate;
            Created = created;
            Updated = updated;
        }

        public static Car Create(
            OwnerId ownerId,
            string brand,
            string model,
            DateOnly manufacturedDate)
        {
            return new(
                CarId.CreateUnique(),
                ownerId,
                brand,
                model,
                manufacturedDate,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
