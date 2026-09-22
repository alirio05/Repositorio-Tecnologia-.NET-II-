using Microsoft.EntityFrameworkCore;
using Nuget_Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Nuget_Persistence.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(
            object id,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(id);

            return await _dbSet.FindAsync(
                new object[] { id },
                cancellationToken);
        }

        public async Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> filter,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            IQueryable<TEntity> query = _dbSet;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(
                filter,
                cancellationToken);
        }

        public async Task<TEntity?> GetOneByAsync(
            Expression<Func<TEntity, bool>> filter,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            IQueryable<TEntity> query = _dbSet;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(
                filter,
                cancellationToken);
        }

        public async Task<PagedResult<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            bool orderDescending = false,
            bool asNoTracking = true,
            bool splitQuery = false,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includes)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageNumber),
                    "pageNumber must be 1 or greater.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    "pageSize must be 1 or greater.");
            }

            IQueryable<TEntity> query = _dbSet;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes != null && includes.Length > 0)
            {
                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (splitQuery)
            {
                query = query.AsSplitQuery();
            }

            int totalRecords = await query.CountAsync(
                cancellationToken);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var property = typeof(TEntity).GetProperty(
                    orderBy,
                    System.Reflection.BindingFlags.IgnoreCase |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Instance);

                if (property == null)
                {
                    throw new ArgumentException(
                        $"The property '{orderBy}' does not exist on {typeof(TEntity).Name}.",
                        nameof(orderBy));
                }

                query = orderDescending
                    ? query.OrderByDescending(
                        entity => EF.Property<object>(
                            entity,
                            property.Name))
                    : query.OrderBy(
                        entity => EF.Property<object>(
                            entity,
                            property.Name));
            }

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            List<TEntity> data = await query.ToListAsync(
                cancellationToken);

            int totalPage = (int)Math.Ceiling(
                (double)totalRecords / pageSize);

            return new PagedResult<TEntity>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = totalPage
            };
        }

        public async Task AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(
                entity,
                cancellationToken);
        }

        public async Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entities);

            await _dbSet.AddRangeAsync(
                entities,
                cancellationToken);
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(
                cancellationToken);
        }

        public void Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
    }
}
