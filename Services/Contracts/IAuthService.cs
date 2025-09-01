using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts;

public interface IAuthService
{
    Task<ApplicationUser> GetOneUser(string eMail);
    Task<UserDtoForUpdate> GetOneUserForUpdate(string eMail);
    Task<IdentityResult> ResetPassword(ResetPasswordDto model);
    Task Update(UserDtoForUpdate userDto);
}