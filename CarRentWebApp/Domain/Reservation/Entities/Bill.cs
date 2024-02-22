using Domain.Common.Models;
using Domain.Reservation.ValueObjects;

namespace Domain.Reservation.Entities
{
    public sealed class Bill : Entity<BillId>
    {
        public double Price { get; }
        public DateTime BilledDateTime { get; }

        private Bill(
            BillId id,
            double price,
            DateTime billedDateTime) 
            : base(id)
        {
            Price = price;
            BilledDateTime = billedDateTime;
        }

        public static Bill Create(double price, DateTime billedDateTime)
        {
            return new Bill(
                BillId.CreateUnique(),
                price,
                billedDateTime);
        }
    }
}
