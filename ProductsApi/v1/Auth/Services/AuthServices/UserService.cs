using System.Net.Sockets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data.Configurations;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Models;
using ProductsApi.v1.Auth.Services.Exceptions;
using ProductsApi.v1.Auth.Services.Interfaces;

namespace ProductsApi.v1.Auth.Services.AuthServices;

public class UserService : IUserService
{

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    public UserService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async ValueTask<bool> DeleteUserAsync(Guid Id)
    {
       var findUser = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id==Id);
        await _userManager.DeleteAsync(findUser);
        return true;
    }

    public async ValueTask<IList<UsersModel>> GetAllUsersAsync()
    {
        var userList = _userManager.Users.ToList();
        var usersList = new List<UsersModel>();
        foreach(var user in userList)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userWithRole = new UsersModel().MapFromEntities(user,roles);
            usersList.Add(userWithRole);
        }

        return usersList;
        /*userList.Select(x => new UsersModel().MapFromEntity(x)).ToList();*/
    }


    public async ValueTask<UsersModel> UserRoleAsync(UserRoleCreateModel userRoleCreateModel)
    {
        var role = await _roleManager.FindByIdAsync(userRoleCreateModel.RoleId.ToString());
        if(role == null)
        {
            throw new ProductApiException(404, "role not found");
        }
        var user = await _userManager.FindByIdAsync(userRoleCreateModel.UserId.ToString());

        var securityStamp = Guid.NewGuid().ToString();
        await _userManager.UpdateSecurityStampAsync(user);


        if (user is null)
        {
            throw new ProductApiException(404, "user not found");
        }
        var isinRole = await _userManager.IsInRoleAsync(user,role.Name);
        if (!isinRole)
        {
            var rolecreateResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (!rolecreateResult.Succeeded)
            {
                throw new ProductApiException(400, string.Join(", ", rolecreateResult.Errors.Select(x => x.Description)));
            }
        }
        else
        {
            throw new ProductApiException(400, "role_already_added_to_this_user");
        }
        return new UsersModel();

    }
    public async ValueTask<UsersModel> RemoveRoleUserAsync(RemoveRoleFromUserModel removeRoleFromUserModel)
    {
        var role = await _roleManager.FindByIdAsync(removeRoleFromUserModel.RoleId.ToString());
        if (role == null)
        {
            throw new ProductApiException(404, "role not found");
        }
        var user = await _userManager.FindByIdAsync(removeRoleFromUserModel.UserId.ToString());
        if (user is null)
        {
            throw new ProductApiException(404, "user not found");
        }
        var isinRole = await _userManager.IsInRoleAsync(user, role.Name);
        if (isinRole)
        {
            var rolecreateResult = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (!rolecreateResult.Succeeded)
            {
                throw new ProductApiException(400, string.Join(", ", rolecreateResult.Errors.Select(x => x.Description)));
            }
        }
        else
        {
            throw new ProductApiException(400, "role_already_remove_to_this_user");
        }
        return new UsersModel().MapFromEntity(user);
    }
    
}










/*{    public async ValueTask<UsersModel> CreateUserAsync(UserCreateModel user)
    {
        var userModel = await _userManager.FindByEmailAsync(user.Email);

        if (userModel != null)
        {
            throw new ProductApiException(400, "user_already_created");
        }

        var userCreate = new User { Id = Guid.NewGuid(), UserName = user.Username, Email = user.Email };

        var createUser = await _userManager.CreateAsync(userCreate, user.Password);


        await _userManager.AddToRoleAsync(userCreate, user.UserRole.ToString());

        var roles = await _userManager.GetRolesAsync(userCreate);


        if (!createUser.Succeeded)
        {
            throw new ProductApiException(400, "user_can_not_succeeded");
        }



        return new UsersModel().MapFromEntities(userCreate, roles);
    } }
*/



/*    public async ValueTask<UserModel> CreateAsync(UserCreateModel user)
    {
        var userModel = await _userModel.FindByEmailAsync(user.Email);
        var checkPassword = await _userModel.CheckPasswordAsync(userModel, user.Password);
        if (userModel != null)
        {
            userModel.Username = user.Username;
            userModel.Email = user.Email;
        };
        var createUser = await _userModel.CreateAsync(userModel,user.Password);
        if (!createUser.Succeeded)
        {
            throw new ProductApiException(400, "user_can_not_succeded");
        }
        return new UserModel().MapFromEntity(createUser);
    }*/
