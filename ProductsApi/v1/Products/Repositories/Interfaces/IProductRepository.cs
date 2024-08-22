using ProductsApi.Data.Entities;
using ProductsApi.v1.Common.Repositories.Interfaces;
using ProductsApi.v1.Products.Models;

namespace ProductsApi.v1.Products.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product, ProductFilterModel>
{
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(Guid Id);
    Task<Product> Get(Guid Id);
    Task<List<Product>> GetByFilter(ProductFilterModel model, string[] includes = null);
    Task<int> GetCount(ProductFilterModel model);
}
