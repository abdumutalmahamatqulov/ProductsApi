using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.FileMetadata.Models;

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
        public decimal DiscountedPrice => Price - (Price / 100) * DisCount;
        public bool HasDiscount => DisCount > 0;
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }
        public CategoryModel Category { get; set; }
        public Guid? FileMetadataId { get; set; }
        public FileMetadataModel FileMeta { get; set; }

        public ProductModel MapFromEntity(Product entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Price = entity.Price;
            DisCount = entity.DisCount;
            CreateAt = entity.CreatedAt;
            UpdateAt = entity.UpdatedAt;
            FileMeta = entity.FileMetadata is null ? null : new FileMetadataModel().MapFromEntity(entity.FileMetadata);
            FileMetadataId = entity.FileMetadataId;
            Category = entity.Category is null ? null : new CategoryModel().MapFromEntity(entity.Category);
            CategoryId = entity.CategoryId;
            return this;
        }
    }
}
