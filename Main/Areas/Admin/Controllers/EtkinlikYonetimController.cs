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
            var plainText = System.Text.RegularExpressions.Regex.Replace(etkinlikDto.LongDescription ?? "", "<.*?>", string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(plainText))
            {
                ModelState.AddModelError("LongDescription", "Uzun Açıklama alanı boş bırakılamaz.");
                return View(etkinlikDto);
            }

            if (etkinlikDto.StartDate > etkinlikDto.EndDate)
            {
                ModelState.AddModelError("", "Geçerli bir tarih aralığı seçiniz.");
                return View(etkinlikDto);
            }

            if (_manager.EtkinlikService.GetAllEtkinlik(false).Any(e => e.Title == etkinlikDto.Title))
            {
                ModelState.AddModelError("", "Bu başlıkta bir etkinlik zaten var.");
                return View(etkinlikDto);
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(ext))
            {
                ModelState.AddModelError("file", "Sadece jpg, jpeg veya png formatında dosya yükleyebilirsiniz.");
                return View(etkinlikDto);
            }
            if (file.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("file", "Dosya boyutu 2 MB'dan büyük olamaz.");
                return View(etkinlikDto);
            }

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
        return View(etkinlikDto);
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
        var plainText = System.Text.RegularExpressions.Regex.Replace(etkinlikDto.LongDescription ?? "", "<.*?>", string.Empty).Trim();
        if (string.IsNullOrWhiteSpace(plainText))
        {
            ModelState.AddModelError("LongDescription", "Uzun Açıklama alanı boş bırakılamaz.");
            return View(etkinlikDto);
        }


        if (!string.IsNullOrEmpty(etkinlikDto.Title)
            && !string.IsNullOrEmpty(etkinlikDto.ShortDescription)
            && !string.IsNullOrEmpty(etkinlikDto.LongDescription)
            && etkinlikDto.StartDate != default
            && etkinlikDto.EndDate != default)
        {
            if (etkinlikDto.StartDate > etkinlikDto.EndDate)
            {
                ModelState.AddModelError("", "Geçerli bir tarih aralığı seçiniz.");
                return View(etkinlikDto);
            }
            
            if (_manager.EtkinlikService.GetAllEtkinlik(false).Any(e => e.Title == etkinlikDto.Title && e.Id != etkinlikDto.Id))
            {
                ModelState.AddModelError("", "Bu başlıkta bir etkinlik zaten var.");
                return View(etkinlikDto);
            }

            if (file is not null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("file", "Sadece jpg, jpeg veya png formatında dosya yükleyebilirsiniz.");
                    return View(etkinlikDto);
                }
                if (file.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("file", "Dosya boyutu 2 MB'dan büyük olamaz.");
                    return View(etkinlikDto);
                }

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

        return View(etkinlikDto);
    }

    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
        _manager.EtkinlikService.DeleteEtkinlik(id);
        return RedirectToAction("Index");
    }
}

