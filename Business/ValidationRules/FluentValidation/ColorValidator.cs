using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Brand>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
