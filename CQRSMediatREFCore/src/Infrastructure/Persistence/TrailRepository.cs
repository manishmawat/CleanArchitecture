using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class TrailRepository:ITrailRepository
    {
        private readonly ITrailDbContext _dbContext;
        private readonly IMediator _mediator;
        public TrailRepository(ITrailDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }
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
            await SaveChangesAsync();
            return response.Entity.Id;
        }

        public async Task<Trail> UpdateTrail(Trail trail)
        {
            var response = _dbContext.Trails.Update(trail);
            await SaveChangesAsync();
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
            await SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvent(_dbContext);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
