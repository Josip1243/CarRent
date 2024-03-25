using Application.Cars.Commands;
using Contracts.Cars;
using Domain.Car;
using Mapster;

namespace WebApi.Common.Mapping
{
    public class CarMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateCarRequest Request, Guid OwnerId), AddCarCommand>()
                .Map(dest => dest.OwnerId, src => src.OwnerId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Car, CarResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.OwnerId, src => src.OwnerId.Value);
        }
    }
}
