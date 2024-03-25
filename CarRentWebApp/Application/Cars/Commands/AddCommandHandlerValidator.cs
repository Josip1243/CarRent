using FluentValidation;

namespace Application.Cars.Commands
{
    public class AddCommandHandlerValidator : AbstractValidator<AddCarCommand>
    {
        public AddCommandHandlerValidator() 
        {
            RuleFor(x => x.Brand).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Model).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ManufacturedDate).NotEmpty().LessThan(DateOnly.FromDateTime(DateTime.UtcNow));
        }
    }
}
