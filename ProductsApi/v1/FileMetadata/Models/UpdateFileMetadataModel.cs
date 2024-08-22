namespace ProductsApi.v1.FileMetadata.Models;

public class UpdateFileMetadataModel
{
    public Guid Id { get; set; }
    public IFormFile formFile { get; set; }
}
