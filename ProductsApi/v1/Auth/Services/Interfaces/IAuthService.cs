using System.Linq.Expressions;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Models;

namespace ProductsApi.v1.Auth.Services.Interfaces;

public interface IAuthService
{
    ValueTask<UserModel> Registration(RegisterModel user);
    ValueTask<TokenModel> Login(LoginModel model);

}