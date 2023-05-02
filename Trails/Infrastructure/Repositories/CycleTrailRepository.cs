using Domain.Abstractions;
using Trails.Domain.Entities;
using Trails.Infrastructure;

namespace Infrastructure.Repositories
{
    public sealed class CycleTrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CycleTrailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(CycleTrail cycleTrail)
        {
            _dbContext.Set<CycleTrail>().Add(cycleTrail);
        }
    }
}
