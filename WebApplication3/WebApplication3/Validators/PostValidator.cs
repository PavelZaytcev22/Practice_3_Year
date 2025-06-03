using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для должности
    /// </summary>
    public class PostValidator : AbstractValidator<Post>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public PostValidator() 
        {
            RuleFor(u => u.PostId).NotNull().WithMessage("Id должен быть определен")
                .GreaterThan(0).WithMessage("больше чем 0");
            RuleFor(u => u.PostName).MaximumLength(20).WithMessage("Длина не больше 20 символов")
                .NotNull().WithMessage("Должно быть название");
            RuleFor(u => u.Salary).NotNull().WithMessage("Зарплата должна быть не null")
                .GreaterThan(500).WithMessage("Должно быть больше ");
        }
    }
}
