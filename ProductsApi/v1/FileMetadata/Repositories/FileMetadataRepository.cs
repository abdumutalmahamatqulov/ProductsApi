using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Contexts;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.FileMetadata.Repositories.Interfaces;
namespace ProductsApi.v1.FileMetadata.Repositories;

public class FileMetadataRepository : IFileMetadataRepository
{
    private readonly AppDbContext _context;

    public FileMetadataRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<ProductsApi.Data.Entities.FileMetadata> Create(Data.Entities.FileMetadata entity)
    {
        var fileMetadataCreate = new Data.Entities.FileMetadata();
        fileMetadataCreate.Id = Guid.NewGuid();
        fileMetadataCreate.Name = entity.Name;
        fileMetadataCreate.Extension = entity.Extension;
        fileMetadataCreate.Body = entity.Body;
        fileMetadataCreate.CreatedDate = DateTime.Now;
        fileMetadataCreate.ModifiedDate = DateTime.Now;

        await _context.FileMetadatas.AddAsync(fileMetadataCreate);
        await _context.SaveChangesAsync();

        return fileMetadataCreate;
    }
    public async ValueTask<Data.Entities.FileMetadata> Update(Data.Entities.FileMetadata entity)
    {
        var fileMetadata = await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == entity.Id);
        if (fileMetadata == null)
        {
            throw new ProductApiException(204, "file_is_null");
        }
        fileMetadata.Name = entity.Name;
        fileMetadata.Extension = entity.Extension;
        fileMetadata.Body = entity.Body;
        fileMetadata.CreatedDate = entity.CreatedDate;
        _context.FileMetadatas.Update(fileMetadata);
        await _context.SaveChangesAsync();
        return fileMetadata;
    }
    public async ValueTask<Data.Entities.FileMetadata> Delete(Guid id)
    {
        var deleteFile = await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == id);
        if(deleteFile is not null)
        {
            _context.FileMetadatas.Remove(deleteFile);
            await _context.SaveChangesAsync();
            return deleteFile;
        }
        throw new ProductApiException(204, "this_file_is_null");

    }
    public async ValueTask<Data.Entities.FileMetadata> Get(Guid id)
    {
        return await _context.FileMetadatas.FirstOrDefaultAsync(f => f.Id == id);
    }
    public List<Data.Entities.FileMetadata> GetAll()
    {
        return _context.FileMetadatas.ToList();
    }
}

/*        foreach (var item in entity)
        {

            var fullName = Path.Combine("", Path.GetExtension(item));
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fullName);
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await item.CopyToAsync(fileStream);
            }

            //var fileModel = new FileMetadataModel().MapFromEntity(fileMetadataCreate);
        }*/