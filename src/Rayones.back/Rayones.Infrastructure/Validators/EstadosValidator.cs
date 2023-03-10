using FluentValidation;
using Rayones.Core.DTOs;
using Rayones.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Infrastructure.Validators
{
    public class EstadosValidator : AbstractValidator<EstadosDTO>
    {
        public EstadosValidator()
        {
            RuleFor(post => post.Descripcion)
                    .NotNull()
                    .Length(5, 50);
            RuleFor(post => post.Color)
                    .NotNull()
                    .Length(5, 50);
        }

    }
}
