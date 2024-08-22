using System.Text;
using ProductsApi.Data.Entities;
using ProductsApi.v1.FileMetadata.Models;
using ProductsApi.v1.FileMetadata.Services.Interfaces;
using ProductsApi.v1.FileMetadata.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ProductsApi.v1.FileMetadata.Services;

public class FileMetadataService : IFileMetadataService
{
    private readonly IFileMetadataRepository _fileMetadataRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public FileMetadataService(IFileMetadataRepository fileMetadataRepository, IHttpContextAccessor httpContextAccessor)
    {
        _fileMetadataRepository = fileMetadataRepository;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async ValueTask<FileMetadataModel> CreateAsync(CreateFileMetadataModel model)
    {
        var filemetadata = new Data.Entities.FileMetadata();
        try
        {
            var someString = model.Files.FileName;
            if(true)
            {
                using (var stream = new MemoryStream())
                {
                    model.Files.CopyTo(stream);
                    filemetadata.Name = someString;
                    filemetadata.Extension = someString.Substring(someString.LastIndexOf(".") + 1);
                    filemetadata.Body = Convert.ToBase64String(stream.ToArray());
                }
                filemetadata = await _fileMetadataRepository.Create(filemetadata);

                return new FileMetadataModel().MapFromEntity(filemetadata);

            }
            else
            {
                throw new FileNotFoundException($"File not Found {someString}");
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync($"Error: {ex.Message}");
            throw;
        }
    }
    public  async ValueTask<bool> Delete(Guid Id)
    {
        var findFile = await _fileMetadataRepository.Delete(Id);
        if(findFile != null)
        {
            return true;
        }
        return false;
       

    }
    public async ValueTask<FileMetadataModel> Update(UpdateFileMetadataModel model)
    {

        var filemetadata = new Data.Entities.FileMetadata();
        try
        {
            var someString = model.formFile.FileName;
            if (true)
            {
                using (var stream = new MemoryStream())
                {
                    model.formFile.CopyTo(stream);
                    filemetadata.Id = model.Id;
                    filemetadata.Name = someString;
                    filemetadata.Extension = someString.Substring(someString.LastIndexOf(".") + 1);
                    filemetadata.Body = Convert.ToBase64String(stream.ToArray());
                }

                await _fileMetadataRepository.Update(filemetadata);

                return new FileMetadataModel().MapFromEntity(filemetadata);

            }
            else
            {
                throw new FileNotFoundException($"File not Found {someString}");
            }
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync($"Error: {ex.Message}");
            throw;
        }

    }
    public async ValueTask<List<FileMetadataModel>> GetAll()
    {
        return  await ValueTask.FromResult(_fileMetadataRepository.GetAll().Select(s=> new FileMetadataModel().MapFromEntity(s)).ToList());
    }
    public async ValueTask<FileMetadataModel> GetAsync(Guid id)
    {
        return new FileMetadataModel().MapFromEntity(await _fileMetadataRepository.Get(id));
    }

    public async Task<(Stream, string, string)> GetAsStream(Guid id)
    {
        var entity = await _fileMetadataRepository.Get(id);
        var mediaType = GetMediaType(entity.Extension);
        httpContextAccessor.HttpContext.Response.Headers.ContentDisposition = "fileName=statis_" + entity.Name;
        httpContextAccessor.HttpContext.Response.Headers.ContentType = mediaType;
        var stream = new MemoryStream(Convert.FromBase64String(entity.Body));
        return (stream, mediaType, entity.Name);
    }

    private string GetMediaType(string extension)
    {
        switch(extension.ToLower())
        {
            case "png": return MediaTypeNames.Image.Png;
            case "jpg": return MediaTypeNames.Image.Jpeg;
            case "jpeg": return MediaTypeNames.Image.Jpeg;
            case "icon": return MediaTypeNames.Image.Icon;
            case "json": return MediaTypeNames.Application.Json;
            case "pdf": return MediaTypeNames.Application.Pdf;
            case "zip": return MediaTypeNames.Application.Zip;

            case "css": return MediaTypeNames.Text.Css;
            case "html": return MediaTypeNames.Text.Html;
        }
       
        return "application/" + extension;
    }
}
