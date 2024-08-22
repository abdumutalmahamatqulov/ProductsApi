using Microsoft.AspNetCore.Identity;
using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Auth.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }

    public virtual UserModel MapFromEntity(User entity)
    {
        Id = entity.Id;
        Username = entity.UserName;
        Email = entity.Email;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
        BirthDate = entity.BirthDate;
        return this;
    }


}
