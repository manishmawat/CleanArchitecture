using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviors;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using MassTransit;

using System.Reflection;
using Application.Trails.Commands.CreateTrail.Mapper;

using Azure.Identity;
using Infrastructure.Utility;
using static System.Net.WebRequestMethods;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Events.TrailCreatedEventHandler).Assembly));
            configuration.AddAzureKeyVault(
                new Uri(configuration.GetValue<string>(Constants.KeyVaultConfiguration__KeyVaultURL)?? $"https://trailwalker.vault.azure.net/"), 
                new DefaultAzureCredential());

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host("localhost", "/", h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq();
            //});

            services.AddMassTransit(x =>
            {
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(configuration.GetValue<string>(Constants.TrailCreated_ServiceBus_TopicName));
                    cfg.Message<TrailCreated>(c =>
                    {
                        c.SetEntityName(nameof(TrailCreated));
                    });
                });
            });

            //Condition if InMemoryDatabase is enabled or not
            if (configuration.GetValue<bool>(Constants.UseInMemoryDatabase))
            {
                services.AddDbContext<TrailDbContext>(options => options.UseInMemoryDatabase(Constants.UseInMemoryDatabase));
            }
            else if(configuration.GetValue<bool>(Constants.UseSqlite))
            {
                services.AddDbContext<TrailDbContext>(options => options.UseSqlite($"Data Source = SqliteTrailDb.db"));
            }
            else
            {
                services.AddDbContext<TrailDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(Constants.DefaultConnection)));
            }

            services.AddScoped<ITrailDbContext>(provider => provider.GetRequiredService<TrailDbContext>());
            services.AddScoped<ITrailRepository, TrailRepository>();
            services.AddScoped<TrailDbContextInitialiser>();

            //services.AddMediatR(cfg =>
            //    cfg.RegisterServicesFromAssembly(typeof(Events.TrailCreatedEventHandler).Assembly));

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host("localhost", "/", h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});

            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq();
            //});



            return services;
        }
    }
}
