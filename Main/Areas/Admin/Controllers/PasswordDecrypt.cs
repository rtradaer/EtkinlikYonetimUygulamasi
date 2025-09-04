using System.Threading.Tasks;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Helpers;

namespace Main.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PasswordDecrypt : Controller
{
    private readonly IServiceManager _manager;

    public PasswordDecrypt(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        return View(new DecryptionDto() { });
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] DecryptionDto decryptionDto)
    {
        var user = await _manager.AuthService.GetOneUser(decryptionDto.Email);
        decryptionDto.EncryptedPassword = user.EncryptedPassword;
        return View(decryptionDto);
    }

    [HttpPost]
    public IActionResult Decrypt([FromForm] DecryptionDto decryptionDto)
    {
        decryptionDto.DecryptedPassword = EncryptionHelper.Decrypt(decryptionDto.EncryptedPassword);
        return View("Index", decryptionDto);
    }

}