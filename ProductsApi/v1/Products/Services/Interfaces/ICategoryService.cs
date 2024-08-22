using ProductsApi.Data.Page;
using ProductsApi.v1.Products.Models;

namespace ProductsApi.v1.Products.Services.Interfaces
{
    public interface ICategoryService
    {
        ValueTask<CategoryModel> Get(Guid id);
        ValueTask<CategoryModel> Create(CategoryCreateModel model);
        ValueTask<CategoryModel> UpdateModel(CategoryUpdateModel model);
        ValueTask<PagedResult<CategoryModel>> GetAll(CategoryFilterModel filter);
        ValueTask<bool> Delete(Guid id);
    }
}
