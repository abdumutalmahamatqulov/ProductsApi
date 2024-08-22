using System.ComponentModel.DataAnnotations;
using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Models;

public class CategoryCreateModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public Category ToEntity()
    {
        var createcategory = new Category();
        createcategory.Id = Guid.NewGuid();
        createcategory.Name = this.Name;
        createcategory.Description = this.Description;
        return createcategory;
    }
}
