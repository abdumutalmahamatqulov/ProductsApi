using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Entities;
using ProductsApi.Data.Page;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Products.Models;
using ProductsApi.v1.Products.Repositories;
using ProductsApi.v1.Products.Repositories.Interfaces;
using ProductsApi.v1.Products.Services.Interfaces;

namespace ProductsApi.v1.Products.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async ValueTask<CategoryModel> Get(Guid id)
    {
        return new CategoryModel().MapFromEntity(await _categoryRepository.Get(id));
    }
    public async ValueTask<CategoryModel> Create(CategoryCreateModel model)
    {
        try
        {
            var newCategory = model.ToEntity();
            await _categoryRepository.Create(newCategory);
            return await ValueTask.FromResult(newCategory);
        }
        catch (ProductApiException ex)
        {
            throw new ProductApiException(400, $"{ex.Message}");
        }
    }
/*    public async ValueTask<CategoryModel> Update(CategoryUpdateModel model)
    {
        try
        {
            var newCategory = model.ToEntity();

            await _categoryRepository.Update(newCategory);
            return await ValueTask.FromResult(newCategory);
        }
        catch(ProductApiException ex)
        {
            throw new ProductApiException(400, $"{ex.Message}");
        }
    }*/
    public async ValueTask<PagedResult<CategoryModel>> GetAll(CategoryFilterModel filter)
    {
        var count = await _categoryRepository.GetCount(filter);
        var list = await _categoryRepository.GetByFilter(filter);
        return PagedResult.Create(list.Select(x => new CategoryModel().MapFromEntity(x)).ToList(), filter.PageIndex, filter.PageSize, count);
    }
    public async ValueTask<CategoryModel> UpdateModel(CategoryUpdateModel model)
    {
        var updateModel = model.ToEntity();
        await _categoryRepository.Update(updateModel);
        return new CategoryModel().MapFromEntity(updateModel);
    }
    public async ValueTask<bool> Delete(Guid id)
    {
        await _categoryRepository.Delete(id);
        return true;
    }
}
