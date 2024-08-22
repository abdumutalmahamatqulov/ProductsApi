using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsApi.Data.Entities;
using ProductsApi.Data.Page;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.FileMetadata.Models;
using ProductsApi.v1.FileMetadata.Repositories.Interfaces;
using ProductsApi.v1.FileMetadata.Services.Interfaces;
using ProductsApi.v1.Products.Models;
using ProductsApi.v1.Products.Repositories.Interfaces;
using ProductsApi.v1.Products.Services.Interfaces;

namespace ProductsApi.v1.Products.Services;

public class ProductService : IProductService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFileMetadataService _fileMetadataService;
    public ProductService(ICategoryRepository categoryRepository, IProductRepository productRepository, IFileMetadataService fileMetadataService, IFileMetadataRepository fileMetadataRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _fileMetadataService = fileMetadataService;
    }
    public async ValueTask<ProductModel> Get(Guid id)
    {
        return new ProductModel().MapFromEntity(await _productRepository.Get(id));
    }
    public async ValueTask<ProductModel> CreateAsync(ProductCreateModel model)
    {
        try
        {
            Validate(model);
            Category newCategory = new();
            if (!model.CategoryId.HasValue)
            {
                var categoryNew = new Category
                {
                    Name = model.CategoryName,
                    Description = model.CategoryDescription
                };
                newCategory = await _categoryRepository.Create(categoryNew);
            }
            var newProduct = model.ToEntity();
            var documentCreate = await _fileMetadataService.CreateAsync(model.document_down);
            newProduct.FileMetadataId = documentCreate.Id;
            newProduct.CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : newCategory.Id;
            await _productRepository.Create(newProduct);
            return new ProductModel().MapFromEntity(newProduct);
        }
        catch (ProductApiException ex)
        {

            throw new ProductApiException(400, $"product_or_categoryId_is_null_{ex.Message}");
        }
    }
    public async ValueTask<ProductModel> Update(ProducUpdatetModel model)
    {
        try
        {
            Validate(model);
            Category newcategory = new Category();
            if (!model.CategoryId.HasValue)
            {
                var categorynew = new Category
                {
                    Name = model.CategoryName,
                    Description = model.CategoryDescription
                };
                newcategory = await _categoryRepository.Update(categorynew);
            }

            var newProduct = model.ToEntity();

            if (model.FormFile is not null)
            {
                var fileCreateMeta = new v1.FileMetadata.Models.CreateFileMetadataModel()
                {
                    Files = model.FormFile
                };
                var newFile = await _fileMetadataService.CreateAsync(fileCreateMeta);
                newProduct.FileMetadataId = newFile.Id;
               
            }
            
            newProduct.CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : newcategory.Id;
            
            await _productRepository.Update(newProduct);
            return new ProductModel().MapFromEntity(newProduct);
        }
        catch(ProductApiException px)
        {
            throw new ProductApiException(400, $"{px.Message}");
        }
    }

    public async ValueTask<bool> Delete(Guid id)
    {
        await _productRepository.Delete(id);
        return true;
    }

    private void Validate(ProductCreateModel model)
    {
        if (model.Price <= 0)
        {
            throw new Exception("Insert valid value to price:");
        }
        if (model.Discount < 0 || model.Discount >= 100)
        {
            throw new Exception("Discount should be between 0 and 99:");
        }

        if (!model.CategoryId.HasValue && (string.IsNullOrEmpty(model.CategoryName) || string.IsNullOrEmpty(model.CategoryDescription)))
        {
            throw new Exception("Please select category:");
        }
    }
    private void Validate(ProducUpdatetModel model)
    {
        if (model.Price <= 0)
        {
            throw new Exception("Insert valid value to price:");
        }
        if (model.DisCount < 0 || model.DisCount >= 100)
        {
            throw new Exception("Discount should be between 0 and 99:");
        }

/*        if (!model.CategoryId.HasValue)
        {
            throw new Exception("Please select category:");
        }*/
    }

    public async ValueTask<PagedResult<ProductModel>> GetAll(ProductFilterModel filter)
    {
        var count = await _productRepository.GetCount(filter);
        var list = await _productRepository.GetByFilter(filter);
        return PagedResult.Create(list.Select(p => new ProductModel().MapFromEntity(p)).ToList(), filter.PageIndex, filter.PageSize, count);
    }
}
