using ProductsApi.v1.FileMetadata.Models;

namespace ProductsApi.v1.FileMetadata.Services.Interfaces;

public interface IFileMetadataService
{
    ValueTask<FileMetadataModel> CreateAsync(CreateFileMetadataModel model);
    ValueTask<bool> Delete(Guid id);
    ValueTask<FileMetadataModel> Update(UpdateFileMetadataModel model);
    ValueTask<List<FileMetadataModel>> GetAll();
    ValueTask<FileMetadataModel> GetAsync(Guid id);
    Task<(Stream, string, string)> GetAsStream(Guid id);
}
