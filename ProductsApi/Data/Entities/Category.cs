using ProductsApi.Data.Entities.Commons;

namespace ProductsApi.Data.Entities;

public class Category :Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
}
