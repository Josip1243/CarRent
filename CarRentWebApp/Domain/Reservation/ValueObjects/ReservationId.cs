﻿using Domain.CarReview.ValueObjects;
using Domain.Common.Models;

namespace Domain.Reservation.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
