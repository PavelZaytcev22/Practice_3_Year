using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для части поставки
    /// </summary>
    public class SupplieMedicineValidator : AbstractValidator<SupplieMedicine>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public SupplieMedicineValidator() 
        {
            RuleFor(u => u.SupplieMedicineId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u=>u.SupplieId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u=>u.MedicineId).NotNull().WithMessage("id должен быть не null");
            RuleFor(u => u.Count).NotNull().WithMessage("Число должно быть")
                .GreaterThan(-1).WithMessage("Количество больше -1 должно быть");
            RuleFor(u => u.PricePayOne).NotNull().WithMessage("Цена должна быть")
                .GreaterThan(-1).WithMessage("Цена за единицу должна быть больше -1");
        }
    }
}
