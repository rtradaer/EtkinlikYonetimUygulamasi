using System.ComponentModel;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Main.Controllers;

[Authorize(Roles = "User")]
public class ProfileController : Controller
{
    private readonly IServiceManager _manager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public ProfileController(IServiceManager manager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _manager = manager;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        var email = User.Identity.Name;
        var userDto = await _manager.AuthService.GetOneUserForUpdate(email);
        return View(userDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index([FromForm] UserDtoForUpdate userDto)
    {
        if (!ModelState.IsValid)
        {
            return View(userDto);
        }

        if (_userManager.Users.Any(u => u.Email == userDto.Email))
        {
            ModelState.AddModelError("", "Bu E-mail'e sahip bir kullanıcı zaten var.");
            return View(userDto);
        }

        await _manager.AuthService.Update(userDto);
        await _signInManager.RefreshSignInAsync(await _manager.AuthService.GetOneUser(userDto.Email)); // 27 eski emaili almasın 
        return Redirect("/");
    }

    public IActionResult Reset([FromRoute(Name = "id")] string id)
    {
        return View(new ResetPasswordDto()
        {
            Email = id
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reset([FromForm] ResetPasswordDto model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError("","Parolalar uyuşmuyor.");
            return View();
        }

        var result = await _manager.AuthService.ResetPassword(model);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("",
            "Parola en az 8 karakterden oluşmalı, büyük harf, küçük harf, özel karakter ve rakam içermelidir.");
        }

        return View();
    }

}