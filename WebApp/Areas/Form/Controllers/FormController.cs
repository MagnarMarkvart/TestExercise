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
using SelectListGroup = System.Web.Mvc.SelectListGroup;
using SelectListItem = System.Web.Mvc.SelectListItem;

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

        var sectors = await _uow.Sectors.GetAllAsync();
        var userSectors = await _uow.UserInSectors.GetAllAsync(user.Id);
        var enumerable = sectors.ToList();
        var sortedSuperSectors = enumerable.Where(s => s.SuperSectorId == null);
        
        var groupedSectors = await AddSectorsToGroups(sortedSuperSectors, [], null);
        
        var selectedIds = new string[userSectors.Count()];
        var ptr = 0;
        foreach (var uis in userSectors)
        {
            selectedIds[ptr] = uis.SectorId.ToString();
            ptr++;
        }

        var multiSelectList = GetSectorMultiSelectList(groupedSectors, selectedIds);
        
        var vm = new FormViewModel()
        {
            Name = user.Name ?? "",
            AgreesToTerms = user.AgreesToTerms,
            SelectedSectors = multiSelectList
        };

        return View(vm);
    }
    
    // Save Form
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(FormViewModel vm)
    {
        if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
        
        var userId = Guid.Parse(_userManager.GetUserId(User)!);
        
        await _context.UserInSectors
            .Where(uis => uis.AppUserId == userId)
            .ExecuteDeleteAsync();

        var userToUpdate = await _uow.Users.FirstOrDefaultAsync(userId);
        _uow.Users.Update(userToUpdate).Name = vm.Name;
        _uow.Users.Update(userToUpdate).AgreesToTerms = vm.AgreesToTerms;
            
        if (vm.SectorIds.Count > 0)
        {
            foreach (var userInSector in vm.SectorIds.Select(sector => new UserInSector()
                     {
                         SectorWithSuperSectorsName = 
                             GetFullSectorName(_uow.Sectors.FirstOrDefaultAsync(Guid.Parse(sector)).Result),
                         SectorId = Guid.Parse(sector),
                         AppUserId = userId
                     }))
            {
                _uow.UserInSectors.Add(userInSector);
            }
        }

        await _uow.SaveChangesAsync();
        return RedirectToAction("Index", "Home", new { area = "" });

    }
    
    private async Task<List<SectorGroup>> AddSectorsToGroups(IEnumerable<Sector> sectorList,
        List<SectorGroup> sectorGroups, SectorGroup? group)
    {
        foreach (var sector in sectorList)
        {
            var s = await _uow.Sectors.FirstOrDefaultAsync(sector.Id);

            if (s.Sectors == null || s.Sectors.Count == 0)
            {
                group!.SelectableSectors.Add(s);
                continue;
            }

            var g = new SectorGroup { Name = s.Description, SectorId = s.Id};

            if (group == null)
            {
                sectorGroups.Add(g);
            }
            else
            {
                group.Subgroups.Add(g);
            }
            
            await AddSectorsToGroups(s.Sectors, sectorGroups, g);
        }
        
        return sectorGroups;
    }

    private MultiSelectList GetSectorMultiSelectList(List<SectorGroup> groupedSectors, string[] selectedValues,
        List<SelectListItem>? sectorItems = null)
    {
        sectorItems ??= [];

        foreach (var sectorGroup in groupedSectors)
        {
            var group = new SelectListGroup { Name = $"{GetFullSectorName(_uow.Sectors.FirstOrDefaultAsync(sectorGroup.SectorId).Result)}" };
            
            sectorItems.AddRange(sectorGroup.SelectableSectors
                .Select(sector => new SelectListItem
                {
                    Value = sector.Id.ToString(), 
                    Text =  sector.Description.Replace("&amp;", "&"),
                    Group = group
                }));
            
            if (sectorGroup.Subgroups.Count > 0)
            {
                GetSectorMultiSelectList(sectorGroup.Subgroups, selectedValues, sectorItems);
            }
        }

        return new MultiSelectList(sectorItems, "Value", "Text", selectedValues, "Group.Name");
    }
    
    private string GetFullSectorName(Sector sector)
    {
        var stack = new Stack<string>();
        while (sector.SuperSectorId != null)
        {
            stack.Push(sector.Description);
            sector = _uow.Sectors.FirstOrDefaultAsync((Guid) sector.SuperSectorId).Result;
        }
        stack.Push(sector.Description);

        var name = "";
        while (stack.Count != 0)
        {
            if (stack.Count != 1)
            {
                var part = $"({stack.Pop()}) --> ";
                name += part;
                continue;
            }

            name += stack.Pop();
        }

        return name;
    }
}