using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class SupplieMedicineValidator : AbstractValidator<SupplieMedicine>
    {
        public SupplieMedicineValidator() 
        {
            RuleFor(u => u.SuplieMedicineId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u=>u.SuplieId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u=>u.MedicineId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u => u.Count).NotNull().WithMessage("Число должно быть")
                .GreaterThan(0).WithMessage("Количество больше 0 должно быть");
            RuleFor(u => u.PricePayOne).NotNull().WithMessage("Цена должна быть")
                .GreaterThan(0).WithMessage("Цена за единицу должна быть больше 0");
        }
    }
}
