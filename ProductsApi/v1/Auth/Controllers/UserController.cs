using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.v1.Auth.Models;
using ProductsApi.v1.Auth.Services.AuthServices;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Auth.Services.Interfaces;

namespace ProductsApi.v1.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }
    [HttpDelete("DeleteUser")]
    [Authorize(Roles = "SuperAdmin")]
    public async ValueTask<IActionResult> Detele(Guid id)
    {
        return Ok(await _userService.DeleteUserAsync(id));
    }
    [HttpPost("UserRoleCreate")]
    public async ValueTask<IActionResult> RoleCreate([FromForm]UserRoleCreateModel model)
    {
        try
        {

            return Ok(await _userService.UserRoleAsync(model));
        }
        catch (ProductApiException pr)
        {
            return BadRequest(new
            {
                global= pr.Message,
            });
        }
    }
    [HttpDelete("RemoveRoleUserAsync")]
    public async ValueTask<IActionResult> RemoveRoleUserAsync([FromForm]RemoveRoleFromUserModel removeRoleFromUserModel)
    {
        try
        {

            return Ok(await _userService.RemoveRoleUserAsync(removeRoleFromUserModel));
        }
        catch (ProductApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }
}






















/*    [HttpPost("CreateUser")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public async ValueTask<IActionResult> Create([FromForm]UserCreateModel model)
    {
        try
        {

            return Ok(await _userService.CreateUserAsync(model));
        }
        catch (ProductApiException ex)
        {
            return BadRequest(new
            {
                global = ex.Message,
            });
        }
    }*/