﻿using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Queries.Products;

namespace Atomiv.Template.Infrastructure.Queries.Validation.Products
{
    public class ViewProductQueryValidator : BaseValidator<ViewProductQuery>
    {
        public ViewProductQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
