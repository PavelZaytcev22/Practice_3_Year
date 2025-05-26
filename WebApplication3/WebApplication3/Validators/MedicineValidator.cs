using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class MedicineValidator : AbstractValidator<Medicine>
    {
        public MedicineValidator() 
        {
            RuleFor(u => u.ManufacturerId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.MedicineId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.MedicineName).NotNull().WithMessage("Название должно быть")
                .MaximumLength(30).WithMessage("Название не больше 30 сиволов");
        }
    }
}
