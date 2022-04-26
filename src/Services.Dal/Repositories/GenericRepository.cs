using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Common.Exceptions;
using Services.Dal.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Repositories;

public class GenericRepository : IGenericRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public GenericRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public void Add<TEntity>(TEntity entity) where TEntity : class,IBaseEntity
    {
        _appDbContext.Set<TEntity>().Add(entity);
    }

    public async Task<TEntity> Delete<TEntity>(Guid id) where TEntity : class,IBaseEntity
    {
        var entity = await _appDbContext.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            throw new ValidationException($"Object of type {typeof(TEntity)} with id { id } not found");
        }

        _appDbContext.Set<TEntity>().Remove(entity);

        return entity;
    }

    public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class,IBaseEntity
    {
        return await _appDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById<TEntity>(Guid id) where TEntity : class,IBaseEntity
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TEntity> GetByIdWithInclude<TEntity>(Guid id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class,IBaseEntity
    {
        var query = IncludeProperties(includeProperties);
        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class,IBaseEntity
    {
        IQueryable<TEntity> entities = _appDbContext.Set<TEntity>();
        foreach (var includeProperty in includeProperties)
        {
            entities = entities.Include(includeProperty);
        }

        return entities;
    }
}
