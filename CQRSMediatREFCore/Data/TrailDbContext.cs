using CQRSMediatREFCore.Entities;
using Microsoft.EntityFrameworkCore;
namespace CQRSMediatREFCore.Data
{
    public class TrailDbContext : DbContext
    {
        public TrailDbContext(DbContextOptions<TrailDbContext> options) : base(options)
        { }

        public DbSet<Trail> Trails => Set<Trail>();
    }
}
