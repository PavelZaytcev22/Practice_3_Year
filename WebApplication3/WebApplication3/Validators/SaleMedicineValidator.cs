using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class SaleMedicineValidator : AbstractValidator<SaleMedicine>
    {
        public SaleMedicineValidator() 
        {
            RuleFor(u => u.SaleMedecineId).NotNull().WithMessage("id должен быть");
            RuleFor(u=>u.ChequeId).NotNull().WithMessage("id должен быть");
            RuleFor(u=>u.MedecineId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.Count).NotNull().WithMessage("Количество должно быть")
                .GreaterThan(0).WithMessage("Количество должно быть больше 0");
            RuleFor(u => u.PriceSellOne).NotNull().WithMessage("Должна быть цена за ед.")
                .GreaterThan(0).WithMessage("Цена должна быть больше 0 за ед.");
        }
    }
}
