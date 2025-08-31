using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Main.Components;

public class UserNameViewComponent : ViewComponent
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserNameViewComponent(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public string Invoke()
    {
        var userId = HttpContext.User?.Identity?.IsAuthenticated == true ? _userManager.GetUserId(HttpContext.User) : null;
        if (userId == null)
            return string.Empty;

        var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            return string.Empty;

        // İsim ve soyisim birleştir
        return string.Concat(user.FirstName ?? "", " ", user.LastName ?? "").Trim();
    }
}