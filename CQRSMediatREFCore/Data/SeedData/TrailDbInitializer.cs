using CQRSMediatREFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatREFCore.Data.SeedData
{
    public class TrailDbInitializer
    {
        internal static void Initialize(TrailDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            dbContext.Database.EnsureCreated();

            if(dbContext.Trails.Any()) return;

            var list = new List<Trail>()
            {
                new Trail() { Id = Guid.NewGuid(), Name = "Swan Lake Trail", Distance = 2.2 },
                new Trail() { Id = Guid.NewGuid(), Name = "Rough Trail", Distance = 4.5 }
            };
            
            dbContext.Trails.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
