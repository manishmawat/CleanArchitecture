using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Condition if InMemoryDatabase is enabled or not
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TrailDbContext>(options => options.UseInMemoryDatabase("InMemoryTrailDb"));
            }
            else if(configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<TrailDbContext>(options => options.UseSqlite($"Data Source = SqliteTrailDb.db"));
            }
            else
            {
                services.AddDbContext<TrailDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<ITrailDbContext>(provider => provider.GetRequiredService<TrailDbContext>());
            services.AddScoped<ITrailRepository, TrailRepository>();
            services.AddScoped<TrailDbContextInitialiser>();
            return services;
        }
    }
}
