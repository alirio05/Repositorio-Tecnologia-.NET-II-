using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Nuget_Persistence.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(
            object id,
            CancellationToken cancellationToken = default);

        Task<TEntity?> GetOneAsync(
            Expression<Func<TEntity, bool>> filter,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default);

        Task<PagedResult<TEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            bool orderDescending = false,
            bool asNoTracking = true,
            bool splitQuery = false,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includes);

        Task AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default);

        Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }

    public class PagedResult<TEntity>
        where TEntity : class
    {
        public List<TEntity> Data { get; set; } = new List<TEntity>();

        public int TotalRecords { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }
    }
}
