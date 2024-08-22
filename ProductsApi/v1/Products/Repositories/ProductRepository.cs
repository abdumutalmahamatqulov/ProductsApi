using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Common.Repositories;
using ProductsApi.v1.Common.Repositories.Interfaces;
using ProductsApi.v1.Products.Models;
using ProductsApi.v1.Products.Repositories.Interfaces;

namespace ProductsApi.v1.Products.Repositories;

public class ProductRepository : BaseRepository<Product, ProductFilterModel>, IProductRepository
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
        try
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (ProductApiException ex)
        {
            throw new ProductApiException(400,ex.Message);
        }

    }
    public async Task<Product> Delete(Guid Id)
    {
        try
        {
            await _context.Products.Where(p => p.Id == Id)
                .ExecuteDeleteAsync();
/*            _context.Products.Remove(new Product { Id = Id });
            await _context.SaveChangesAsync();*/
            return null;
        }
        catch (ProductApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> Update(Product product)
    {
        await _context.Products.Include(x => x.Category).Where(p => p.Id == product.Id)
            .ExecuteUpdateAsync(
            p => p.SetProperty(p => p.Name, p => product.Name)
            .SetProperty(p=>p.Description,p =>product.Description)
            .SetProperty(p=>p.Price,p=>product.Price)
            .SetProperty(p=>p.DisCount,p=>product.DisCount)
            .SetProperty(p=>p.CreatedAt,p=>product.CreatedAt)
            .SetProperty(p=>p.UpdatedAt,p=>DateTime.UtcNow)
            .SetProperty(p => p.CategoryId, p => product.CategoryId)
            .SetProperty(p=>p.FileMetadataId,p=>product.FileMetadataId == Guid.Empty ? p.FileMetadataId : product.FileMetadataId)
            );
        return await _context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == product.Id);
    }
    public async Task<Product> Get(Guid Id)
    {
        try
        {

            return await _context.Products.Include(x=>x.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(Id));
        }
        catch (ProductApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    protected override IQueryable<Product> GetQuery(ProductFilterModel model)
    {
        var query = _context.Products.Include(x=>x.Category).AsNoTracking();
        if(model.IncludeFileMetadata.HasValue && model.IncludeFileMetadata.Value)
        {
            query = query.Include(x => x.FileMetadata);
        }

        if(model.Id.HasValue && model.Id.Value != Guid.Empty)
        {
            query = query.Where(x => x.Id == model.Id);
        }
        if(!string.IsNullOrEmpty(model.Name) && !string.IsNullOrWhiteSpace(model.Name))
        {
            query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{model.Name.Trim().ToLower()}%"));
        }
        return query;
    }
}
