﻿using System.Linq.Expressions;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.Exceptions;
using degree_management.constracts.Pagination;
using degree_management.constracts.Specifications;
using degree_management.domain.Entities;
using degree_management.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace degree_management.infrastructure.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity>? _dbSet;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        _context = dbContext;
        _dbSet = _context.Set<TEntity>();
    }

    private static readonly Func<DbContext, Task<List<TEntity>>> GetAllCompiledQuery =
        EF.CompileAsyncQuery<DbContext, List<TEntity>>(context => context.Set<TEntity>()!.ToList());

    private static readonly Func<DbContext, Expression<Func<TEntity, bool>>, Task<List<TEntity>>> FindCompiledQuery =
        EF.CompileAsyncQuery<DbContext, Expression<Func<TEntity, bool>>, List<TEntity>>(
            (context, expression) => context.Set<TEntity>().Where(expression).ToList()
        );
    private static readonly Func<DbContext, Func<TEntity, bool>, Task<TEntity>> GetCompiledQuery =
        EF.CompileAsyncQuery<DbContext, Func<TEntity, bool>, TEntity>(
            (context, func) => context.Set<TEntity>().FirstOrDefault(func)!
        );
    private static readonly Func<DbContext, string, object, Task<TEntity>> GetByFieldCompiledQuery =
        EF.CompileAsyncQuery<DbContext, string, object, TEntity>(
            (context, fieldName, value) => context.Set<TEntity>()
                .FirstOrDefault(e => EF.Property<object>(e, fieldName).Equals(value))!
        );
    
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await GetAllCompiledQuery(_context);
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbSet!.Where(expression).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> func, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet!.FirstOrDefaultAsync(func, cancellationToken);
        return entity!;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet!.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(Expression<Func<TEntity, bool>> func, object payload, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet!.FirstOrDefaultAsync(func, cancellationToken) ?? throw new NotFoundException($"{typeof(TEntity).Name} not found");
        _context.Entry(entity).CurrentValues.SetValues(payload);
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> func, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet!.FirstOrDefaultAsync(func, cancellationToken) ?? throw new NotFoundException($"{typeof(TEntity).Name} not found");
        _dbSet.Remove(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet!.AddRangeAsync(entities, cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        _dbSet!.UpdateRange(entities);
    }

    public async Task<IEnumerable<TResult>> GetSelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>>? conditions, CancellationToken cancellationToken = default)
    {
        if (conditions != null)
            return await _dbSet!.Where(conditions).Select(selector).ToListAsync(cancellationToken);
        return await _dbSet!.Select(selector).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
    {
        return (IEnumerable<SelectDto>)await _dbSet!.Select(selector).ToListAsync();
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> GetByFieldAsync(string filedName, object value,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet!.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<object>(e, filedName).Equals(value), cancellationToken) ??
               throw new NotFoundException($"{typeof(TEntity).Name} not found");
    }

    public async Task<PaginatedResult<TEntity>> GetPageAsync(PaginationRequest paginationRequest, 
        CancellationToken cancellationToken = default!, Expression<Func<TEntity, bool>>? conditions = null)
    {
        int pageIndex = paginationRequest.PageIndex >= 0 ? paginationRequest.PageIndex : 0;
        var pageSize = paginationRequest.PageSize >= 1 ? paginationRequest.PageSize : 1;
        var totalCount = await _dbSet!.AsNoTracking().LongCountAsync(cancellationToken);

        IEnumerable<TEntity> entities = await _dbSet!.AsNoTracking().WhereIf(conditions != null, conditions).Skip(pageSize*pageIndex).Take(pageSize).ToListAsync(cancellationToken);
        var pagedResult = new PaginatedResult<TEntity>(pageIndex, pageSize, totalCount, entities);
        return pagedResult;
        
    }
    
    public async Task<PaginatedResult<TResult>> GetPageWithIncludesAsync<TResult>(
        PaginationRequest paginationRequest,
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? conditions = null,
        List<Expression<Func<TEntity, object>>>? includes = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet!.AsNoTracking();

        if (conditions != null)
            query = query.Where(conditions);

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var data = await query
            .Skip(paginationRequest.PageSize * paginationRequest.PageIndex)
            .Take(paginationRequest.PageSize)
            .Select(selector)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<TResult>(
            data: data,
            pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex,
            count: totalCount
        );
    }
    
    public async Task<TEntity> GetByFieldWithIncludesAsync(
        string fieldName, 
        object value,
        List<Expression<Func<TEntity, object>>>? includes = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet!.AsNoTracking();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var entity = await query.FirstOrDefaultAsync(
            e => EF.Property<object>(e, fieldName).Equals(value), 
            cancellationToken
        );

        return entity ?? throw new NotFoundException($"{typeof(TEntity).Name} with {fieldName} '{value}' not found");
    }

 
}