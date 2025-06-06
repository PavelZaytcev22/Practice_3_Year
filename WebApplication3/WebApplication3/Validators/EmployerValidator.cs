﻿using FluentValidation;
using WebApplication3.Models;

namespace WebApplication3.Validators
{
    /// <summary>
    /// Валидатор для работника
    /// </summary>
    public class EmployerValidator : AbstractValidator<Employer>
    {
        /// <summary>
        /// Конструктор с настройкими валидации под каждый атрибут сущности
        /// </summary>
        public EmployerValidator() 
        {
            RuleFor(u => u.EmployerId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.PostId).NotNull().WithMessage("id должен быть");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("Номер телефона должен быть")
                .Matches("^(7|8)(\\d{10})$").WithMessage("Начинается с 7 или 8");
            RuleFor(u => u.Fio).NotEmpty().WithMessage("ФИО должно быть");
        }
    }
}
