using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Main.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Main.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class EtkinlikYonetimController : Controller
{
    private readonly IServiceManager _manager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public EtkinlikYonetimController(IServiceManager manager, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _manager = manager;
        _mapper = mapper;
        _userManager = userManager;
    }

    public IActionResult Index(EtkinlikRequestParameters p)
    {
        var etkinlikler = _manager.EtkinlikService.GetAllEtkinlikWithDetails_2(p);
        Pagination pagination = new()
        {
            CurrentPage = p.PageNumber,
            ItemsPerPage = p.PageSize,
            TotalItems = _manager.EtkinlikService.GetAllEtkinlik(false).Count()
        };

        EtkinlikListViewModel etkinlikListViewModel = new()
        {
            Etkinlikler = etkinlikler,
            Pagination = pagination
        };

        return View(etkinlikListViewModel);
    }

    public IActionResult EtkinlikRegister()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EtkinlikRegister([FromForm] EtkinlikDtoCreate etkinlikDto, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            etkinlikDto.ImageUrl = String.Concat("/images/", file.FileName);   // init değil set
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            etkinlikDto.CreatedBy = user.FirstName;

            _manager.EtkinlikService.CreateEtkinlik(etkinlikDto);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
        var etkinlikDto = _manager.EtkinlikService.GetOneEtkinlikForUpdate(id, false);
        return View(etkinlikDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] EtkinlikDto etkinlikDto, IFormFile file)
    {

        if (!string.IsNullOrEmpty(etkinlikDto.Title)
        && !string.IsNullOrEmpty(etkinlikDto.ShortDescription)
        && !string.IsNullOrEmpty(etkinlikDto.LongDescription)
        && etkinlikDto.StartDate != default
        && etkinlikDto.EndDate != default)
        {
            if (file is not null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                etkinlikDto.ImageUrl = String.Concat("/images/", file.FileName);

            }
            else
            {
                etkinlikDto.ImageUrl = _manager.EtkinlikService.GetOneEtkinlikForUpdate(etkinlikDto.Id, false).ImageUrl;
            }

            etkinlikDto.CreatedAt = _manager.EtkinlikService.GetOneEtkinlikForUpdate(etkinlikDto.Id, false).CreatedAt;
            _manager.EtkinlikService.UpdateEtkinlik(etkinlikDto);
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
        _manager.EtkinlikService.DeleteEtkinlik(id);
        return RedirectToAction("Index");
    }
}

