namespace Contracts.Cars
{
    public record CarResponse(
        Guid Id,
        string Brand,
        string Model,
        DateOnly ManufacturedDate,
        Guid OwnerId);
}
