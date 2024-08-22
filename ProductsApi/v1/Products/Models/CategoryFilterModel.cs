using ProductsApi.Data.Configurations;

namespace ProductsApi.v1.Products.Models;

public class CategoryFilterModel: PaginationParams
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
