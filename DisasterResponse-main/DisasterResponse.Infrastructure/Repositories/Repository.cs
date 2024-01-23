using System.Linq.Expressions;
using DisasterResponse.Domain.Core;
using DisasterResponse.Domain.Repositories;
using DisasterResponse.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponse.Infrastructure.Repositories;

public class Repository : IRepository
{
    private readonly DisasterDbContext _context;
    public Repository(DisasterDbContext context) => _context = context;

    public void Add<TEntity>(TEntity entity)
        => _context.Add(entity!);

    public void Update<TEntity>(TEntity entity)
        => _context.Update(entity!);


    public async Task<TEntity> GetById<TEntity, TKey>(TKey id)
        where TEntity : Entity<TKey> where TKey : IEquatable<TKey>
        => await _context.Set<TEntity>().FirstAsync(e => e.Id.Equals(id));

    public async Task<(int Count, List<TEntity> Entities)> QueryPagination<TEntity>(int pageindex, int pageSize,
        Expression<Func<TEntity, bool>>? filter = null) where TEntity : class
    {
        var queryable = _context.Set<TEntity>().AsQueryable();
        if (filter is not null) queryable = queryable.Where(filter!);

        return (await queryable.CountAsync(),
            await queryable.Skip((pageindex - 1) * pageSize).Take(pageSize).ToListAsync());
    }

    public async Task<(int Count, List<TEntity> Entities)> QueryPaginationOrderBy<TEntity>(
        int pageindex, 
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null) where TEntity : class
    {
        var queryable = _context.Set<TEntity>().AsQueryable();
        if (filter is not null) queryable = queryable.Where(filter!);
        if (orderBy is not null) queryable = queryable.OrderByDescending(orderBy);
        
        return (await queryable.CountAsync(),
            await queryable.Skip((pageindex - 1) * pageSize).Take(pageSize).ToListAsync());
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);

    public void Delete<TEntity>(TEntity entity) where TEntity : class
        => _context.Set<TEntity>().Remove(entity);

    public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        => _context.Set<TEntity>();
}