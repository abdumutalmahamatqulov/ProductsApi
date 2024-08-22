using ProductsApi.Data.Page;
using ProductsApi.v1.Products.Models;

namespace ProductsApi.v1.Products.Services.Interfaces;

public interface IProductService
{
    ValueTask<ProductModel> CreateAsync(ProductCreateModel model);
    ValueTask<ProductModel> Get(Guid id);
    ValueTask<PagedResult<ProductModel>> GetAll(ProductFilterModel filter);
    ValueTask<ProductModel> Update(ProducUpdatetModel model);
    ValueTask<bool> Delete(Guid id);
}
