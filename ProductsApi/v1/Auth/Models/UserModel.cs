using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Auth.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual UserModel MapFromEntity(User entity)
    {
        Id = entity.Id;
        Username = entity.UserName;
        Email = entity.Email;
        Password = entity.PasswordHash;
        return this;
    }
}
