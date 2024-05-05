using App.Contracts.DAL;
using App.DAL.EF;
using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Form.ViewModels;

namespace WebApp.Areas.Form.Controllers;

[Authorize]
[Area("Form")]
public class FormController : Controller
{
    private readonly IAppUnitOfWork _uow;
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _context;

    public FormController(IAppUnitOfWork uow, UserManager<AppUser> userManager, AppDbContext context)
    {
        _uow = uow;
        _userManager = userManager;
        _context = context;
    }

    // GET: Form
    public async Task<IActionResult> Index()
    {
        var user = await _uow.Users
            .FirstOrDefaultAsync(Guid.Parse(_userManager.GetUserId(User)!));
        
        var allSectors = await _uow.Sectors.GetAllAsync();
        
        var sectorList = allSectors.Select(s => new SelectListItem { 
            Value = s.Id.ToString(), 
            Text = s.Description 
        }).ToList();
        
        var vm = new FormViewModel()
        {
            Name = user.Name,
            AgreesToTerms = user.AgreesToTerms,
            SectorSelectList = new SelectList(sectorList, "Value", "Text")
        };
        
        if (user.UserInSectors != null)
        {
            vm.SelectedSectors = await _uow.Sectors.GetUserSectorsAsync(user.UserInSectors!);
        }

        return View(vm);
    }
    
    // Save Form
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(FormViewModel vm)
    {
        var userId = Guid.Parse(_userManager.GetUserId(User)!);
        if (ModelState.IsValid)
        {
            await _context.UserInSectors
                .Where(uis => uis.AppUserId == userId)
                .ExecuteDeleteAsync();

            var userToUpdate = await _uow.Users.FirstOrDefaultAsync(userId);
            _uow.Users.Update(userToUpdate).Name = vm.Name;
            _uow.Users.Update(userToUpdate).AgreesToTerms = vm.AgreesToTerms;
            
            if (vm.SelectedSectors != null)
            {
                foreach (var userInSector in vm.SelectedSectors.Select(sector => new UserInSector()
                         {
                             SectorId = sector.Id,
                             AppUserId = userId
                         }))
                {
                    _uow.UserInSectors.Add(userInSector);
                }
            }

            await _uow.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}