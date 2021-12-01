using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).MinimumLength(2).WithMessage("Araba ismi ve modeli 2 karakterden uzun olmalıdır.");

            RuleFor(c=>c.ColorId).NotEmpty();
            RuleFor(c => c.BrandId).NotEmpty();

            RuleFor(c=>c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Fiyat 0'dan küçük olamaz.");

            

        }
    }
}
