using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.v1.Auth.Models;
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
    public async ValueTask<IActionResult> Login(UserCreateModel model)
    {
        return Ok(await _authService.Login(model));
    }
    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromForm]UserCreateModel model)
    {
        return Ok(await _authService.Registration(model));
    }
}
