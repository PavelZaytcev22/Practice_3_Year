using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator() 
        {
            RuleFor(u => u.SupplierId).NotNull().WithMessage("Номер телефона обязателен");
            RuleFor(u => u.SupplierName).NotNull().WithMessage("Должно быть имя");
        }
    }
}
