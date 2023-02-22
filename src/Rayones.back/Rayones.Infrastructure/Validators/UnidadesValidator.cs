using FluentValidation;
using Rayones.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Infrastructure.Validators
{
    public class UnidadesValidator : AbstractValidator<UnidadesDTO>
    {
        public UnidadesValidator()
        {
            RuleFor(post => post.Descripcion)
                    .NotNull()
                    .Length(5, 50);
        }
    }
}
