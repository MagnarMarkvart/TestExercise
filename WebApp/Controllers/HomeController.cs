using System.Diagnostics;
using App.Contracts.DAL;
using App.DAL.EF;
using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAppUnitOfWork _uow;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public HomeController(
        ILogger<HomeController> logger,
        IAppUnitOfWork uow,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager
        )
    {
        _logger = logger;
        _uow = uow;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        if (!_signInManager.IsSignedIn(User))
        {
            return View();
        }
        
        var user = await _uow.Users
            .FirstOrDefaultAsync(Guid.Parse(_userManager.GetUserId(User)!));

        var sectorList = await _uow.UserInSectors.GetAllAsync(user.Id);
        
        var vm = new UserDetailsViewModel()
        {
            Name = user.Name,
            AgreesToTerms = user.AgreesToTerms,
            SelectedSectors = sectorList
        };

        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}