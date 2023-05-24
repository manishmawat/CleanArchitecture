using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface ITrailDbContext
    {
        DbSet<Trail> Trails { get; }
        DbSet<City> Cities { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
