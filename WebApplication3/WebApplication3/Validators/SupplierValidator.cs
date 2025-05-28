using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для поставщика
    /// </summary>
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public SupplierValidator() 
        {
            RuleFor(u => u.SupplierId).NotNull().WithMessage("Номер телефона обязателен");
            RuleFor(u => u.SupplierName).NotNull().WithMessage("Должно быть имя");
        }
    }
}
