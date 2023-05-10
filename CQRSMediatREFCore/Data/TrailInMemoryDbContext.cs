using CQRSMediatREFCore.Entities;
using Microsoft.EntityFrameworkCore;
namespace CQRSMediatREFCore.Data
{
    public class TrailInMemoryDbContext : DbContext
    {
        public TrailInMemoryDbContext(DbContextOptions<TrailDbContext> options) : base(options)
        { }

        public DbSet<Trail> Trails { get; set; }
    }
}
