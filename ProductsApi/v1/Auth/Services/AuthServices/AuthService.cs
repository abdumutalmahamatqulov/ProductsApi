using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Models;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Auth.Services.Extentions;
using ProductsApi.v1.Auth.Services.Interfaces;

namespace ProductsApi.v1.Auth.Services.AuthServices;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenRepository _tokenGenerator;
    public AuthService( ITokenRepository tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public async Task<TokenModel> Login(UserCreateModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!checkPassword)
        {
            throw new ProductApiException(401, "Email or password is incorrect");
        }
        var token = _tokenGenerator.CreateToken(user);
        return new TokenModel { Token = token };
        
    }

    public async ValueTask<UserModel> Registration(UserCreateModel user)
    {
        User newUser = new User()
        {
            UserName = user.Username,
            Email = user.Email,
        };
        var registerUser = await _userManager.CreateAsync(newUser, user.Password);
        if (!registerUser.Succeeded)
        {
            throw new ProductApiException(401, "user_can_not_create");
        }
        return new UserModel().MapFromEntity(newUser);
    }
}
