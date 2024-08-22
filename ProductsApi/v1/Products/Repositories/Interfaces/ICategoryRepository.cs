using ProductsApi.Data.Entities;
using ProductsApi.v1.Common.Repositories.Interfaces;
using ProductsApi.v1.Products.Models;

namespace ProductsApi.v1.Products.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category,CategoryFilterModel>
{
    Task<Category> Create(Category entity);
    Task<Category> Update(Category entity);

    Task<Category> Delete(Guid id);
    Task<Category> Get(Guid id);
    Task<List<Category>> GetByFilter(CategoryFilterModel model, string[] includes = null);
    Task<int> GetCount(CategoryFilterModel model);
}
