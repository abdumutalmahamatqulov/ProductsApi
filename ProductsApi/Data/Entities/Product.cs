using System.ComponentModel.DataAnnotations.Schema;
using ProductsApi.Data.Entities.Commons;

namespace ProductsApi.Data.Entities;

public class Product: Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int DisCount { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid FileMetadataId { get; set; }
    public FileMetadata FileMetadata { get; set; }
}
