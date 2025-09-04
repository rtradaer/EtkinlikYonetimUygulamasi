using System.ComponentModel;
using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;
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

        if (_userManager.Users.Any(u => u.Email == userDto.Email && u.Id != userDto.Id))
        {
            ModelState.AddModelError("", "Bu E-mail'e sahip bir kullanıcı zaten var.");
            return View(userDto);
        }

        await _manager.AuthService.Update(userDto);
        await _signInManager.RefreshSignInAsync(await _manager.AuthService.GetOneUser(userDto.Email));
        TempData["success"] = "Bilgileriniz güncellendi.";
        return RedirectToAction("Index");
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
            ModelState.AddModelError("", "Şifreler uyuşmuyor.");
            return View();
        }

        if (ModelState.IsValid)
        {
            var user = await _manager.AuthService.GetOneUser(model.Email);
            user.EncryptedPassword = Services.Helpers.EncryptionHelper.Encrypt(model.Password);
            await _manager.AuthService.Update(new UserDtoForUpdate
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PlainPassword = model.Password
            });

            var result = await _manager.AuthService.ResetPassword(model);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    if (item.Code.Contains("PasswordTooShort"))
                        ModelState.AddModelError("", "Parola en az 8 karakterden oluşmalıdır.");
                    else if (item.Code.Contains("PasswordRequiresNonAlphanumeric"))
                        ModelState.AddModelError("", "Parola en az bir özel karakter içermelidir.");
                    else if (item.Code.Contains("PasswordRequiresDigit"))
                        ModelState.AddModelError("", "Parola en az bir rakam içermelidir.");
                    else if (item.Code.Contains("PasswordRequiresLower"))
                        ModelState.AddModelError("", "Parola en az bir küçük karakter içermelidir.");
                    else if (item.Code.Contains("PasswordRequiresUpper"))
                        ModelState.AddModelError("", "Parola en az bir büyük karakter içermelidir.");
                }
                ModelState.AddModelError("",
                "Mevcut parolanız hatalı.");
                return View();
            }
        }
        TempData["success"] = "Parolanız başarıyla değiştirildi.";
        return RedirectToAction("Index");
    }

}