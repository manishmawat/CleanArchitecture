using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public abstract class ITrailDbContext:DbContext
    {
        public ITrailDbContext(DbContextOptions context) :base(context)
        {
            
        }
        public abstract DbSet<Trail> Trails { get; }
        public abstract DbSet<City> Cities { get; }

    }
}
