using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviors;
using Application.Trails.Commands;
using Application.Trails.Commands.CreateTrail;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            //Add Pipeline behaviors, add in the sequence in which you want to execute.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizeBehavior<,>));
            services.AddScoped<IValidator<CreateTrailCommand>, CreateTrailCommandValidator>();
            //services.AddValidatorsFromAssemblyContaining<CreateTrailCommandValidator>();
            return services;
        }
    }
}
