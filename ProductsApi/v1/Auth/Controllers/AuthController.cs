using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.v1.Auth.Models;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Auth.Services.Interfaces;

namespace ProductsApi.v1.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("Login")]
    public async ValueTask<IActionResult> Login([FromForm]LoginModel model)
    {
        try
        {

            return Ok(await _authService.Login(model));
        }
        catch (ProductApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }
    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody]RegisterModel model)
    {
        try
        {

            return Ok(await _authService.Registration(model));
        }
        catch (ProductApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }

/*    [HttpGet("secureapi")]
    [Authorize]
    public async Task<IActionResult> AuthTest()
    {
        return Ok("success");
    }*/
}
 