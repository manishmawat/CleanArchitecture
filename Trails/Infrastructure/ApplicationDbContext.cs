using Microsoft.EntityFrameworkCore;
using Trails.Application.Abstractions.Data;
using Trails.Domain.Abstractions;
using Trails.Domain.Primitives;

namespace Trails.Infrastructure
{
    public sealed class ApplicationDbContext:DbContext,IUnitOfWork,IDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : Entity
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChnagesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
