using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Products.Models;
using ProductsApi.v1.Products.Services.Interfaces;

namespace ProductsApi.v1.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet("Get")]
    public async ValueTask<IActionResult> Get([FromQuery]Guid Id)
    {
        return Ok(await _productService.Get(Id));
    }
    [HttpGet("GetAll")]

    public async ValueTask<IActionResult> GetAll([FromQuery]ProductFilterModel model)
    {
        return Ok(await _productService.GetAll(model));
    }
    [HttpPost("Create")]
    public async ValueTask<IActionResult> Create([FromForm]ProductCreateModel model)
    {
        try
        {

            return Ok(await _productService.CreateAsync(model));
        }
        catch (ProductApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message
            });
        }
    }
    [HttpPut("Update")]

    public async ValueTask<IActionResult> Update([FromForm]ProducUpdatetModel model)
    {
        try
        {
            return Ok(await _productService.Update(model));

        }
        catch(ProductApiException pe)
        {
            return BadRequest(new
            {
                global = pe.Message
            });
        }
    }
    [HttpDelete("Delete")]

    public async ValueTask<IActionResult> Delete([FromForm]Guid Id)
    {
        return Ok(await _productService.Delete(Id));
    }
}
