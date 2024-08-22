using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
    public AuthService(ITokenRepository tokenGenerator, UserManager<User> userManager)
    {
        _tokenGenerator = tokenGenerator;
        _userManager = userManager;
    }

    public async ValueTask<TokenModel> Login(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            throw new ProductApiException(400, "user_not_Found");
        }
        var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        var roles = await _userManager.GetRolesAsync(user);
        if (!checkPassword)
        {
            throw new ProductApiException(401, "Email or password is incorrect");
        }
        //var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        var token = _tokenGenerator.CreateToken(user, roles);
        return new TokenModel() { Token = token,Roles = roles.ToArray(),User = new UserModel().MapFromEntity(user)};
        
    }

    public async ValueTask<UserModel> Registration(RegisterModel user)
    {
        User newUser = new User()
        {
            UserName = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate
           
        };
        var registerUser = await _userManager.CreateAsync(newUser, user.Password);
        if (!registerUser.Succeeded)
        {

            throw new ProductApiException(500, string.Join(", ", registerUser.Errors.Select(x => x.Description)));
        }
        return new UserModel().MapFromEntity(newUser);
    }
}
