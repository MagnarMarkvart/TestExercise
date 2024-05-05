using App.Contracts.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserInSectorsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public UserInSectorsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserInSectors
        public async Task<IActionResult> Index()
        {
            var res = await _uow.UserInSectors.GetAllAsync();
            return View(res);
        }

        // GET: UserInSectors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInSector = await _uow.UserInSectors
                .FirstOrDefaultAsync(id.Value);

            return View(userInSector);
        }

        // GET: UserInSectors/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserInSectorsCreateViewModel()
            {
                Sectors = new SelectList(await _uow.Sectors.GetAllAsync(),
                    nameof(Sector.Id), nameof(Sector.Description)),
                Users = new SelectList(await _uow.Users.GetAllAsync(),
                    nameof(AppUser.Id), nameof(AppUser.Email))
            };
            
            return View(vm);
        }

        // POST: UserInSectors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserInSectorsCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.UserInSectors.Add(vm.UserInSector);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.Sectors = new SelectList(await _uow.Sectors.GetAllAsync(), nameof(Sector.Id), nameof(Sector.Description), vm.UserInSector.SectorId);
            vm.Users = new SelectList(await _uow.Users.GetAllAsync(), nameof(AppUser.Id), nameof(AppUser.Email), vm.UserInSector.AppUserId);
            return View(vm);
        }

        // GET: UserInSectors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInSector = await _uow.UserInSectors
                .FirstOrDefaultAsync(id.Value);

            return View(userInSector);
        }

        // POST: UserInSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.UserInSectors.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
