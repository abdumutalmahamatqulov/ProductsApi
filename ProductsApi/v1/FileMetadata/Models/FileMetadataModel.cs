using System.Text;
using ProductsApi.Data.Entities;

namespace ProductsApi.v1.FileMetadata.Models;

public class FileMetadataModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public FileMetadataModel MapFromEntity(ProductsApi.Data.Entities.FileMetadata entity)
    {

        Id = entity.Id;
        Name = entity.Name;
        Extension = entity.Extension;
        Body = entity.Body;
        CreatedDate = entity.CreatedDate;
        ModifiedDate = entity.ModifiedDate;
        return this;

    }
}