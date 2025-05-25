using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для клиента
    /// </summary>
    public class ClientValidator : AbstractValidator<Client>
    {
        /// <summary>
        /// конструктор валидатора со всеми полями модели
        /// </summary>
        public ClientValidator()
        {
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("Номер телефона обязателен")
                    .Length(11).WithMessage("Длина 11 цифр без пробелов")
                    .Matches("^(7|8)(d{10})$").WithMessage("Начинается с 7 или 8");
            RuleFor(u => u.ClientId).NotNull().WithMessage("Id обязателен");
            RuleFor(u => u.Discount).Must(o => o < 100 && o >= 0).WithMessage("Скидка не больше 100%");
        }

       
    }
}
