using CQRSMediatREFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatREFCore.Data.Repository
{
    public class TrailRepository:ITrailRepository
    {
        private readonly TrailDbContext _dbContext;
        public TrailRepository(TrailDbContext dbContext) => _dbContext = dbContext;
        public Task<IEnumerable<Trail>> GetTrails()
        {
            var response = _dbContext.Trails.AsEnumerable();
            return Task.FromResult(response);
        }

        public Task<Trail?> GetTrail(Guid id)
        {
            return _dbContext.Trails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Guid> AddTrail(Trail trail)
        {
            var response = _dbContext.Trails.Add(trail);
            await _dbContext.SaveChangesAsync();
            return response.Entity.Id;
        }

        public async Task<Trail> UpdateTrail(Trail trail)
        {
            var response= _dbContext.Trails.Update(trail);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<bool> DeleteTrail(Guid id)
        {
            var entity = _dbContext.Trails.FirstOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return false;
            }
            var response = _dbContext.Trails.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
