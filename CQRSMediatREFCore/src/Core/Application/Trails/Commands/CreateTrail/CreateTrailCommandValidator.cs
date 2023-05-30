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
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
