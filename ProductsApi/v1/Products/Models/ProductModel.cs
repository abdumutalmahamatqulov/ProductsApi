using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DisCount { get; set; }
        public Guid CategoryId { get; set; }
        public decimal DiscountedPrice => Price - Price / 100 * DisCount;
        public bool HasDiscount => DisCount > 0;
        public DateTime CreateData { get; set; }
        public CategoryModel Category { get; set; }

        public ProductModel MapFromEntity(Product entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Price = entity.Price;
            DisCount = entity.DisCount;
            CreateData = entity.CreateData;
            Category = entity.Category is null ? null : entity.Category;
            return this;
        }
    }
}
