using ProductsApi.Data.Configurations;
using ProductsApi.v1.Auth.Models;

namespace ProductsApi.v1.Auth.Services.Interfaces;

public interface IUserService
{
   // ValueTask<UsersModel> CreateUserAsync(UserCreateModel user);
    ValueTask<UsersModel> RemoveRoleUserAsync(RemoveRoleFromUserModel removeRoleFromUserModel);
    ValueTask<UsersModel> UserRoleAsync(UserRoleCreateModel userRoleCreateModel);
    ValueTask<bool> DeleteUserAsync(Guid Id);
    ValueTask<IList<UsersModel>> GetAllUsersAsync();
}
