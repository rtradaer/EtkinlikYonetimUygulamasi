using Microsoft.AspNetCore.Mvc;

namespace Main.Areas.Admin.Controllers;

[Area("Admin")]
public class EtkinlikController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
