using ProductsApi.Data.Entities;

namespace ProductsApi.v1.FileMetadata.Repositories.Interfaces;

public interface IFileMetadataRepository
{
    ValueTask<Data.Entities.FileMetadata> Create(Data.Entities.FileMetadata entity);
    ValueTask<Data.Entities.FileMetadata> Update(Data.Entities.FileMetadata entity);
    ValueTask<Data.Entities.FileMetadata> Delete(Guid id);
    ValueTask<Data.Entities.FileMetadata> Get(Guid id);
    List<Data.Entities.FileMetadata> GetAll();
}
