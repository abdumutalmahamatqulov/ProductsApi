using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ProductsApi.Data.Entities;
using ProductsApi.v1.FileMetadata.Models;

namespace ProductsApi.v1.Products.Models
{
    public class ProducUpdatetModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int DisCount { get; set; }
        public Guid? CategoryId { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? CategoryName { get; set; }
        [AllowNull]
        public string? CategoryDescription { get; set; }
        public Product ToEntity()
        {
            var addProduct = new Product();
            addProduct.Id = this.Id;
            addProduct.Name = this.Name;
            addProduct.Description = this.Description;
            addProduct.Price = this.Price;
            addProduct.DisCount = this.DisCount;
            return addProduct;

        }
    }
}
