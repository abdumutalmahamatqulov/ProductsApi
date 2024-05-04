using System.ComponentModel.DataAnnotations;

namespace ProductsApi.v1.Auth.Models;

public class UserCreateModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required] 
    public string Password { get; set; }
}
