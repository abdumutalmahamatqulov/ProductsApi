using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Products.Repositories.Interfaces;

namespace ProductsApi.v1.Products.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Category> Create(Category entity)
    {
        var categoryCreate = new Category();
        categoryCreate.Id = entity.Id;
        categoryCreate.Name = entity.Name;
        categoryCreate.Description = entity.Description;
        categoryCreate.CreateDate = DateTime.Now;
        _appDbContext.Categories.Add(categoryCreate);
        await _appDbContext.SaveChangesAsync();
        return categoryCreate;
    }

    public async Task<Category> Update(Category entity)
    {
        var categoryCreate = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
        categoryCreate.Name = entity.Name;
        categoryCreate.Description = entity.Description;
        categoryCreate.CreateDate = entity.CreateDate;
        _appDbContext.Categories.Update(categoryCreate);
        await _appDbContext.SaveChangesAsync();
        return categoryCreate;
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
        return _appDbContext.Categories.FirstOrDefaultAsync(c=>c.Id == id);
    }

    public IQueryable<Category> GetAll(bool includeCategory)
    {
        return _appDbContext.Categories.AsQueryable();
    }
}
