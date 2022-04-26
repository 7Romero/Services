using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Interfaces;

public interface IGenericRepository
{
    Task<TEntity> GetById<TEntity>(Guid id) where TEntity : class,IBaseEntity;

    Task<TEntity> GetByIdWithInclude<TEntity>(Guid id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class,IBaseEntity;

    Task<List<TEntity>> GetAll<TEntity>() where TEntity : class,IBaseEntity;

    Task SaveChangesAsync();

    void Add<TEntity>(TEntity entity) where TEntity : class,IBaseEntity;

    Task<TEntity> Delete<TEntity>(Guid id) where TEntity : class,IBaseEntity;

    //Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity                                                                                   where TDto : class;
}
