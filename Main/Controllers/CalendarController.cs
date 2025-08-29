using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Main.Controllers;

public class CalendarController : Controller
{
    private readonly IServiceManager _manager;

    public CalendarController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var etkinlikler = _manager.EtkinlikService.GetAllEtkinlik(false)
            .Select(e => new
            {
                id = e.Id,
                title = e.Title,
                start = e.StartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                end = e.EndDate.ToString("yyyy-MM-ddTHH:mm:ss")
            }).ToList();

        ViewBag.EtkinliklerJson = JsonSerializer.Serialize(etkinlikler);
        return View();
    }
}