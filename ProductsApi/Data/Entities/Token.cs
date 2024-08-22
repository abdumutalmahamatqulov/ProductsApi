using ProductsApi.v1.Auth.Models;

namespace ProductsApi.Data.Entities;

public class TokenModel
{
    public string Token { get; set; }
    public string[] Roles { get; set; }
    public UserModel User { get; set; }
}