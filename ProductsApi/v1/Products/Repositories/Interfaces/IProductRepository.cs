using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Guid Id);
        Task<Product> Get(Guid Id);
        IQueryable<Product> GetAll(bool includeCategory);
    }
}
