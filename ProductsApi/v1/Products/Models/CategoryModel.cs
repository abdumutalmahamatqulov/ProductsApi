using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Products.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }

    public static implicit operator CategoryModel(Category entity)
    {
        if (entity is null)
            return null;
        return new CategoryModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            CreateDate = entity.CreateDate
        };
    }
}
