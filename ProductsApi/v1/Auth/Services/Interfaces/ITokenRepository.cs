using Microsoft.AspNetCore.Identity;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Models;

namespace ProductsApi.v1.Auth.Services.Interfaces;

public interface ITokenRepository
{
    string CreateToken(User user, IList<string> roles);
}
