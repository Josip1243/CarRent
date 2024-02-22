using Domain.Car.ValueObjects;
using Domain.Common.Models;
using Domain.Owner.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Owner
{
    public sealed class Owner : AggregateRoot<OwnerId>
    {
        public UserId UserId { get; }
        List<CarId> _carIds = new();

        public Owner(
            OwnerId ownerId,
            UserId userId)
            : base(ownerId)
        {
            UserId = userId;
        }

        public IReadOnlyList<CarId> CarIds => _carIds.ToList();
    }
}
