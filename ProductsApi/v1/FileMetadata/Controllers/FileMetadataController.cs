using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.FileMetadata.Models;
using ProductsApi.v1.FileMetadata.Services.Interfaces;

namespace ProductsApi.v1.FileMetadata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileMetadataController : ControllerBase
    {
        private readonly IFileMetadataService _fileMetadataService;

        public FileMetadataController(IFileMetadataService fileMetadataService)
        {
            _fileMetadataService = fileMetadataService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(CreateFileMetadataModel model)
        {
            return Ok(await _fileMetadataService.CreateAsync(model));
        }
        [HttpDelete]
        public async ValueTask<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _fileMetadataService.Delete(id));
            }
            catch (ProductApiException ex)
            {
                return BadRequest(new
                {
                    global = ex.Message,
                });
            }

        }
        [HttpPut]
        public async ValueTask<IActionResult> Update(UpdateFileMetadataModel update)
        {
            try
            {
                return Ok(await _fileMetadataService.Update(update));

            }
            catch(ProductApiException ex)
            {
                return BadRequest(new
                {
                    global = ex.Message
                });
            }
        }
        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            return Ok(await _fileMetadataService.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBase64(Guid id)
        {
            return Ok(await _fileMetadataService.GetAsync(id));
        }

        [HttpGet("{id:guid}/static")]
        public async Task<Stream> GetStaticFile(Guid id)
        {
            var (stream, contentType, fileName) = await _fileMetadataService.GetAsStream(id);
/*            Response.Headers.ContentType = contentType; //teng ikkisi   HttpContext.Response.ContentType = contentType; 
            Response.Headers.ContentDisposition ="fileName=statis_" + fileName;*/
         
            return stream;
        }
    }


}
