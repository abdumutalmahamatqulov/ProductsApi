/*using ProductsApi.Data.Entities;

namespace ProductsApi.v1.Auth.Models;

public class UserRoleModel
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public RoleModel Role { get; set; }
    public UserRoleModel MapFromEntity(UserRole entity)
    {
        UserId = entity.UserId;
        RoleId = entity.RoleId;
        Role = entity.Role is not null ? new RoleModel().MapFromEntity(entity.Role) :
            null;
        return this;
    }
}
*/