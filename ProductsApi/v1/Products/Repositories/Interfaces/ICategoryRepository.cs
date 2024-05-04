using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Create(Category entity);
        Task<Category> Update(Category entity);

        Task<Category> Delete(Guid id);
        Task<Category> Get(Guid id);
        IQueryable<Category> GetAll(bool includeCategory);
    }
}
