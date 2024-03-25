namespace Contracts.Cars
{
    public record CreateCarRequest(string Brand, string Model, DateOnly ManufacturedDate);
}
