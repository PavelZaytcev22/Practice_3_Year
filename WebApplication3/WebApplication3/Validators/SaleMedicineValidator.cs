using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для продажи
    /// </summary>
    public class SaleMedicineValidator : AbstractValidator<SaleMedicine>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public SaleMedicineValidator() 
        {
            RuleFor(u => u.SaleMedecineId).NotNull().WithMessage("id должен быть");
            RuleFor(u=>u.ChequeId).NotNull().WithMessage("id должен быть");
            RuleFor(u=>u.MedecineId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.Count).NotNull().WithMessage("Количество должно быть")
                .GreaterThan(-1).WithMessage("Количество должно быть больше -1");
            RuleFor(u => u.PriceSellOne).NotNull().WithMessage("Должна быть цена за ед.")
                .GreaterThan(-1).WithMessage("Цена должна быть больше -1 за ед.");
        }
    }
}
