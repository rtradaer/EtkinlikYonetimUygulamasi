using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services;

public class AuthManager : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public AuthManager(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ApplicationUser> GetOneUser(string eMail)
    {
        var user = await _userManager.FindByEmailAsync(eMail);
        if (user is not null)
            return user;
        throw new Exception("User could not be found.");
    }

    public async Task<UserDtoForUpdate> GetOneUserForUpdate(string eMail)
    {
        var user = await GetOneUser(eMail);
        UserDtoForUpdate userDto = _mapper.Map<UserDtoForUpdate>(user);
        return userDto;
    }

    public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
    {
        var user = await GetOneUser(model.Email);
        await _userManager.RemovePasswordAsync(user);
        var result = await _userManager.AddPasswordAsync(user, model.Password);
        return result;
    }

    public async Task Update(UserDtoForUpdate userDto)
    {
        var user = await GetOneUser(userDto.UserName);
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;
        user.BirthDate = userDto.BirthDate;
        user.UserName = userDto.Email;
        var result = await _userManager.UpdateAsync(user);

        return;
    }
}