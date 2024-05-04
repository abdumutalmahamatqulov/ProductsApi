using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Products.Repositories.Interfaces;

namespace ProductsApi.v1.Products.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Product> Create(Product product)
    {
        var createProduct = new Product();
        createProduct.Id = Guid.NewGuid();
        createProduct.Name = product.Name;
        createProduct.Description = product.Description;
        createProduct.Price = product.Price;
        createProduct.DisCount = product.DisCount;
        createProduct.CreateData = DateTime.Now;
        _context.Products.Add(createProduct);
        await _context.SaveChangesAsync();
        return createProduct;
    }
    public async Task<Product> Delete(Guid Id)
    {
        try
        {
            _context.Products.Remove(new Product { Id = Id });
            await _context.SaveChangesAsync();
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> Update(Product product)
    {
        var updateProduct = await _context.Products.FirstOrDefaultAsync(p=>p.Id == product.Id);
        updateProduct.Name = product.Name;
        updateProduct.Description = product.Description;
        updateProduct.Price = product.Price;
        updateProduct.DisCount = product.DisCount;
        updateProduct.CreateData = product.CreateData;
        _context.Products.Update(updateProduct);
        await _context.SaveChangesAsync();
        return updateProduct;
    }
    public async Task<Product> Get(Guid Id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(Id));
    }
    public IQueryable<Product> GetAll(bool includeCategory)
    {
        if (includeCategory)
        {
            return _context.Products.Include(x => x.Category);
        }
        return _context.Products.AsQueryable();
    }
}
