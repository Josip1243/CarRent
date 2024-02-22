﻿using Domain.Car.ValueObjects;
using Domain.Common.Models;

namespace Domain.Reservation.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; }

        private BillId(Guid value)
        {
            Value = value;
        }
        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
