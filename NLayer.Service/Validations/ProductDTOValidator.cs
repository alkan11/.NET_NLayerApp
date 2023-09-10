using FluentValidation;
using NlayerCoreApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductDTOValidator:AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required ").NotEmpty().WithMessage("{PropertyName} is not empty ");
        }
    }
}
