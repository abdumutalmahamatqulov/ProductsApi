using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace ProductsApi.Data.Entities;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }

}
