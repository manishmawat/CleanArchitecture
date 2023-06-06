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
    public class TrailDbContext : ITrailDbContext
    {
        public TrailDbContext(DbContextOptions<TrailDbContext> context) : base(context)
        {

        }

        public override DbSet<Trail> Trails => Set<Trail>();
        public override DbSet<City> Cities => Set<City>();
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
