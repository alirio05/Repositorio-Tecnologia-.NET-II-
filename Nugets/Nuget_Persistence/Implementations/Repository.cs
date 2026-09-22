using Microsoft.EntityFrameworkCore;
using Nuget_Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nuget_Persistence.Implementations
{


    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DbContext context;
        private DbContext _context;
        private readonly DbSet<TEntity> _dbSet; 
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(id));
            return await _dbSet.FindAsync(new[] { id }, cancellationToken);
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);
            IQueryable<TEntity> query = _dbSet;
            return await query FirstOrDefaultAsync(filter, cancellationToken);
              }





    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

            ArgumentNullException.ThrowIfNull(entity);
            await _dbSet.AddAsync(entity, cancellationToken);
        }
        
public async void Remove(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity); 
            await Task.Run(() =>
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            });







public void Update(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            if (_context.Entry(entity).State == EntityState.Detached)
            {
            }
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
