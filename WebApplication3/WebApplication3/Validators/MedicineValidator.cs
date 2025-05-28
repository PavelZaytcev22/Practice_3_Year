using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для лекарства
    /// </summary>
    public class MedicineValidator : AbstractValidator<Medicine>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public MedicineValidator() 
        {
            RuleFor(u => u.ManufacturerId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.MedicineId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.MedicineName).NotNull().WithMessage("Название должно быть")
                .MaximumLength(30).WithMessage("Название не больше 30 сиволов");
        }
    }
}
