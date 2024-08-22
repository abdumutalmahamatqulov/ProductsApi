using System.ComponentModel.DataAnnotations;
using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Models;

public class CategoryUpdateModel
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
   
    public Category ToEntity()
    {
        var addCategory = new Category();
        addCategory.Id = this.Id;
        addCategory.Name = this.Name;
        addCategory.Description = this.Description;
        return addCategory;
    }
}
