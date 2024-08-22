using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Common.Repositories;
using ProductsApi.v1.Products.Models;
using ProductsApi.v1.Products.Repositories.Interfaces;

namespace ProductsApi.v1.Products.Repositories;

public class CategoryRepository : BaseRepository<Category,CategoryFilterModel>, ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Category> Create(Category entity)
    {

        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        _appDbContext.Categories.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Category> Update(Category entity)
    {
        await _appDbContext.Categories.Where(c => c.Id == entity.Id)
            .ExecuteUpdateAsync(
            c => c.SetProperty(c=>c.Name,c=>entity.Name)
            .SetProperty(c=>c.Description,c=>entity.Description)
            .SetProperty(c=>c.CreatedAt,c=>entity.CreatedAt)
            .SetProperty(c => c.UpdatedAt,c=>DateTime.UtcNow)
            );
        return await _appDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == entity.Id);

    }

    public async Task<Category> Delete(Guid id)
    {
        var deleteProduct = await _appDbContext.Products.Where(x => x.CategoryId == id).ToListAsync();
        foreach (var product in deleteProduct)
        {
            _appDbContext.Products.Remove(product);
        }
        var category = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        _appDbContext.Categories.Remove(category);
        await _appDbContext.SaveChangesAsync();
        return category;
    }

    public Task<Category> Get(Guid id)
    {
        try
        {
            return _appDbContext.Categories.FirstOrDefaultAsync(c=>c.Id == id);
        }
        catch(ProductApiException ex)
        {
            throw new ProductApiException(500, "category_can_not_Find");
        }

    }

    protected override IQueryable<Category> GetQuery(CategoryFilterModel model)
    {
        var query = _appDbContext.Categories.AsNoTracking();
        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x=>x.Id == model.Id);
        }
        if(!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
        {
            query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{model.Name.Trim().ToLower()}%"));
        }
        return query;
    }
}
