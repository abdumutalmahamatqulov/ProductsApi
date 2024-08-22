using ProductsApi.Data.Configurations;

namespace ProductsApi.v1.Products.Models
{
    public class ProductFilterModel: PaginationParams
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool? IncludeFileMetadata { get; set; }
    }
}
