using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Trails.Commands.CreateTrail
{
    public class CreateTrailCommandValidator:AbstractValidator<CreateTrailCommand>
    {
        public CreateTrailCommandValidator()
        {
            RuleFor(v => v.TrailName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(v => v.TrailDescription)
                .NotNull()
                .NotEmpty()
                .MinimumLength(20);

            RuleFor(v => v.Distance)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
