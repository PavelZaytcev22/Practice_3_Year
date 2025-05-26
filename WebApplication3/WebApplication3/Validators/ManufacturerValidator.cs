using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class ManufacturerValidator : AbstractValidator<Manufacturer>
    {
        public ManufacturerValidator() 
        {
            RuleFor(u => u.ManufacturerId).NotNull().WithMessage("id должно быть");
            RuleFor(u => u.ManufacturerName).NotNull().WithMessage("Название должно быть")
                .MaximumLength(40).WithMessage("Название должно быть строго меньше 41 символов");
        }
    }
}
