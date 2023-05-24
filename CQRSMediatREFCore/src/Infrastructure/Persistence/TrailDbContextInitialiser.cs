using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class TrailDbContextInitialiser
    {
        private readonly ILogger<TrailDbContextInitialiser> _logger;
        private readonly TrailDbContext _dbContext;

        public TrailDbContextInitialiser(ILogger<TrailDbContextInitialiser> logger, TrailDbContext context)
        {
            _logger = logger;
            _dbContext= context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_dbContext.Database.IsSqlServer())
                {
                    await _dbContext.Database.MigrateAsync();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database");
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private async Task TrySeedAsync()
        {
            ArgumentNullException.ThrowIfNull(_dbContext, nameof(_dbContext));

            _dbContext.Database.EnsureCreated();

            if (_dbContext.Trails.Any()) return;

            var list = new List<Trail>()
            {
                new Trail()
                {
                    Id = Guid.NewGuid(), TrailName = "Swan Lake Trail", TrailDescription = "This is new Trail",
                    Distance = 2.2
                },
                new Trail()
                {
                    Id = Guid.NewGuid(), TrailName = "Rough Trail", TrailDescription = "This is another new Trail",
                    Distance = 4.5
                }
            };

            _dbContext.Trails.AddRange(list);
            await _dbContext.SaveChangesAsync();
        }
    }
}
