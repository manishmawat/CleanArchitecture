using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trails.Domain.Primitives;

namespace Trails.Application.Abstractions.Data
{
    public interface IDbContext
    {
        /// <summary>
        /// Gets the database set for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The database set for the specified entity type.</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="id">The entity identifier.</param>
        /// <returns>The maybe instance that may contain the <typeparamref name="TEntity"/> with the specified identifier.</returns>
        Task<TEntity> GetByIdAsync<TEntity>(int id) 
            where TEntity : Entity;

        /// <summary>
        /// Insert the specified entity into the database
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="entity">The entity to be removed from the database.</param>
        void Insert<TEntity>(TEntity entity)
            where TEntity : Entity;

        /// <summary>
        /// Remove the specified entity from the database.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entity">The entity to be removed from the database.</param>
        void Remove<TEntity>(TEntity entity) 
            where TEntity : Entity;

        Task<int> SaveChnagesAsync(CancellationToken cancellationToken = default);

    }
}
