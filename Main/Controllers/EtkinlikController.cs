using Entities.RequestParameters;
using Main.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Main.Controllers;

public class EtkinlikController : Controller
{
    private readonly IServiceManager _manager;

    public EtkinlikController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index(EtkinlikRequestParameters p)
    {
        var etkinlikler = _manager.EtkinlikService.GetAllEtkinlikWithDetails(p);
        Pagination pagination = new Pagination()
        {
            CurrentPage = p.PageNumber,
            ItemsPerPage = p.PageSize,
            TotalItems = _manager.EtkinlikService.GetAllEtkinlik(false).Count()
        };
        EtkinlikListViewModel etkinlikListViewModel = new EtkinlikListViewModel()
        {
            Etkinlikler = etkinlikler,
            Pagination = pagination
        };
        return View(etkinlikListViewModel);
    }

    public IActionResult Details([FromRoute(Name = "id")] int id, EtkinlikRequestParameters p)
    {
        p.PageSize = 5;
        var etkinlikler = _manager.EtkinlikService.GetAllEtkinlikWithDetails(p);
        var model = _manager.EtkinlikService.GetOneEtkinlik(id, false);
        if (etkinlikler.Any(e => e.Id == model.Id))
        {
            p.PageSize = 6;
            etkinlikler = _manager.EtkinlikService.GetAllEtkinlikWithDetails(p, id);
        }

        Pagination pagination = new Pagination()
        {
            CurrentPage = p.PageNumber,
            ItemsPerPage = p.PageSize,
            TotalItems = _manager.EtkinlikService.GetAllEtkinlik(false).Count()
        };

        EtkinlikListViewModel etkinlikListViewModel = new EtkinlikListViewModel()
        {
            Etkinlik = model,
            Etkinlikler = etkinlikler,
            Pagination = pagination
        };

        return View(etkinlikListViewModel);
    }
}