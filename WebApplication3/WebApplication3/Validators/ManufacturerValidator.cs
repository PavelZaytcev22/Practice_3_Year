using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для производителя
    /// </summary>
    public class ManufacturerValidator : AbstractValidator<Manufacturer>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public ManufacturerValidator() 
        {
            RuleFor(u => u.ManufacturerId).NotNull().WithMessage("id должно быть");
            RuleFor(u => u.ManufacturerName).NotNull().WithMessage("Название должно быть")
                .MaximumLength(40).WithMessage("Название должно быть строго меньше 41 символов");
        }
    }
}
