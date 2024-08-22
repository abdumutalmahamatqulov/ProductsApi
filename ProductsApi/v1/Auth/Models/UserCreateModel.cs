using System.ComponentModel.DataAnnotations;
using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Auth.Models;

public class UserCreateModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required] 
    public string Password { get; set; }
    public ERole UserRole { get; set; }
}
