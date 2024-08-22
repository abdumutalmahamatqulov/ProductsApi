using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Configurations;
using ProductsApi.Data.Entities.Commons;
using ProductsApi.v1.Common.Repositories.Interfaces;

namespace ProductsApi.v1.Common.Repositories;

public abstract class BaseRepository<TEntity, TFilter> : IBaseRepository<TEntity, TFilter> where TEntity : Auditable where TFilter : PaginationParams
{
    public virtual async Task<List<TEntity>> GetByFilter(TFilter model, string[] includes = null)
    {
        var query = GetQuery(model);
        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

        }
        model.EnsureOrSetDefaults();
        query = query.Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize);

        return await query.ToListAsync();
    }

    public async Task<int> GetCount(TFilter model)
    {
        var query = GetQuery(model);
        return await query.CountAsync();
    }

    protected abstract IQueryable<TEntity> GetQuery(TFilter model);
}
