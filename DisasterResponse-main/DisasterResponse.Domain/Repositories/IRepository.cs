using System.Linq.Expressions;
using DisasterResponse.Domain.Core;

namespace DisasterResponse.Domain.Repositories;

public interface IRepository
{
    IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    void Add<TEntity>(TEntity entity);
    void Update<TEntity>(TEntity entity);
    Task<TEntity> GetById<TEntity, TKey>(TKey id) where TEntity : Entity<TKey> where TKey : IEquatable<TKey>;

    Task<(int Count, List<TEntity> Entities)> QueryPagination<TEntity>(
        int pageindex,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null)
        where TEntity : class;

    Task<(int Count, List<TEntity> Entities)> QueryPaginationOrderBy<TEntity>(
        int pageindex,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity,object>>? orderBy = null)
        where TEntity : class;
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Delete<TEntity>(TEntity entity) where TEntity : class;
}