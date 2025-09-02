using Entities.Dtos;
using Entities.Models;
using Main.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Helpers;

namespace Main.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromForm] LoginModel model)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("Hata", "Hatalı E-mail veya parola.");
            }
            else
            {
                ModelState.AddModelError("Hata", "Böyle bir kullanıcı bulunamadı.");
            }
        }
        return View();
    }

    public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "Şifreler uyuşmuyor.");
            return View(model);
        }

        var encryptedPassword = EncryptionHelper.Encrypt(model.Password);

        ApplicationUser user = new ApplicationUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            BirthDate = model.BirthDate,
            UserName = model.Email,
            EncryptedPassword = encryptedPassword
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (roleResult.Succeeded)
            {
                TempData["success"] = "Kayıt olma işlemi başarılı.";
                return RedirectToAction("Login");
            }
        }
        else
        {
            foreach (var item in result.Errors)
            {
                if (item.Code.Contains("DuplicateUserName"))
                    continue;
                else if (item.Code.Contains("DuplicateEmail"))
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kayıtlı.");
                else if (item.Code.Contains("PasswordTooShort"))
                    ModelState.AddModelError("", "Parola en az 8 karakterden oluşmalıdır.");
                else if (item.Code.Contains("PasswordRequiresNonAlphanumeric"))
                    ModelState.AddModelError("", "Parola en az bir özel karakter içermelidir.");
                else if (item.Code.Contains("PasswordRequiresDigit"))
                    ModelState.AddModelError("", "Parola en az bir rakam içermelidir.");
                else if (item.Code.Contains("PasswordRequiresLower"))
                    ModelState.AddModelError("", "Parola en az bir küçük karakter içermelidir.");
                else if (item.Code.Contains("PasswordRequiresUpper"))
                    ModelState.AddModelError("", "Parola en az bir büyük karakter içermelidir.");
                else
                    ModelState.AddModelError("", item.Description);
            }
        }

        return View(model);
    }

}