using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    public class SupplieValidator : AbstractValidator<Supplie>
    {
        public SupplieValidator() 
        {
            RuleFor(g => g.SupplieId).NotNull().WithMessage("Нуже id поставки");
            RuleFor(g => g.SupplierId).NotNull().WithMessage("Нужен id поставщика");
            RuleFor(g => g.Date).Matches("^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/[0-9]{4}$").WithMessage("Дата формата дд/мм/гггг")
                .NotNull().WithMessage("Дата должна быть");
            RuleFor(g => g.TotalSum).NotNull().WithMessage("Сумма должна быть определена");
        }
    }
}
