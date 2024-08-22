using System.ComponentModel.DataAnnotations;

namespace ProductsApi.v1.Auth.Models;

public class RegisterModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}
