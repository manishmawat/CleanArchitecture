using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class TrailDbContext : DbContext,ITrailDbContext
    {
        public TrailDbContext(DbContextOptions<TrailDbContext> context) : base(context)
        {

        }

        public DbSet<Trail> Trails => Set<Trail>();
        public DbSet<City> Cities => Set<City>();
    }
}
