using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ProductsApi.Data.Entities;
using ProductsApi.v1.FileMetadata.Models;

namespace ProductsApi.v1.Products.Models;

public class ProductCreateModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int Discount { get; set; }
    [AllowNull]
    public Guid? CategoryId { get; set; }
    [AllowNull]
    public string? CategoryName { get; set; }
    [AllowNull]
    public string? CategoryDescription { get; set; }
    public CreateFileMetadataModel document_down { get; set; }

    public Product ToEntity()
    {
        var productAdd = new Product();
        productAdd.Id = Guid.NewGuid();
        productAdd.Name = this.Name;
        productAdd.Description = this.Description;
        productAdd.DisCount = this.Discount;
        productAdd.Price = this.Price;
        return productAdd;
    }
}
