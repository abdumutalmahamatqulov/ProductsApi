using ProductsApi.Data.Configurations;
using ProductsApi.Data.Entities.Commons;

namespace ProductsApi.v1.Common.Repositories.Interfaces;

public interface IBaseRepository<TEntity, TFilter> where TEntity : Auditable where TFilter : PaginationParams
{
    Task<List<TEntity>> GetByFilter(TFilter model, string[] includes = null);
}
