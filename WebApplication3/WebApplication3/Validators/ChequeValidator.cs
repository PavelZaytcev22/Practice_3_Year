using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для чека
    /// </summary>
    public class ChequeValidator:AbstractValidator<Cheque>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public ChequeValidator()
        {
            RuleFor(u => u.ChequeId).NotNull().WithMessage("id должен быть");
            RuleFor(u=>u.EmployerId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.ClientId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.Date).Matches("^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/[0-9]{4}$").WithMessage("Дата формата дд/мм/гггг")
                .NotNull().WithMessage("Дата должна быть");
            RuleFor(u => u.TotalSum).GreaterThan(-1).WithMessage("Сумма должна быть больше -1");
            RuleFor(u => u.SumDiscount).GreaterThan(-1).WithMessage("Сумма со скидкой должна быть больше -1");
        }
    }
}
