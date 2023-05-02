using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Trails.Application.Abstractions.Data;

namespace Trails.Infrastructure
{
    public static class DependencyInjection
    {
        private static SqliteConnection _sqliteConnection;
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            _sqliteConnection = new SqliteConnection(configuration.GetConnectionString("DefaultConnection"));
            if (_sqliteConnection.State != ConnectionState.Open)
            {
                _sqliteConnection.Open();
            }

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(_sqliteConnection));

            services.AddScoped<IDbContext>(
                serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<IDbConnection>(_ => _sqliteConnection);

            return services;
        }
    }
}
