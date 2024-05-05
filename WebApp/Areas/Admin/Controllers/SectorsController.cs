using App.Contracts.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using Microsoft.AspNetCore.Authorization;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SectorsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public SectorsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Sectors
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Sectors.GetAllAsync();
            return View(res);
        }

        // GET: Sectors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _uow.Sectors
                .FirstOrDefaultAsync(id.Value);

            return View(sector);
        }

        // GET: Sectors/Create
        public async Task<IActionResult> Create()
        {
            var sectors = await _uow.Sectors.GetAllAsync();
            var sectorList = sectors.Select(s => new SelectListItem { 
                Value = s.Id.ToString(), 
                Text = s.Description 
            }).ToList();
            
            sectorList.Insert(0, (new SelectListItem { Text = "[None]", Value = null }));
            
            var vm = new SectorCreateViewModel()
            
            {
                SectorSelectList = new SelectList(sectorList, "Value", "Text")
            };
            return View(vm);
        }

        // POST: Sectors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SectorCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Sectors.Add(vm.Sector);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.SectorSelectList = new SelectList(await _uow.Sectors.GetAllAsync(), nameof(Sector.Id), nameof(Sector.Description), vm.Sector.SuperSectorId);
            return View(vm);
        }

        // GET: Sectors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _uow.Sectors.FirstOrDefaultAsync(id.Value);
            
            var sectors = await _uow.Sectors
                .GetAllAsync();
            var sectorList = sectors.Select(s => new SelectListItem { 
                Value = s.Id.ToString(), 
                Text = s.Description 
            }).ToList();
            
            sectorList.Insert(0, (new SelectListItem { Text = "[None]", Value = null }));
            
            var vm = new SectorCreateViewModel()
            {
                Sector = sector,
                SectorSelectList = new SelectList(sectorList, "Value", "Text")
            };
            return View(vm);
        }

        // POST: Sectors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SectorCreateViewModel vm)
        {
            if (id != vm.Sector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Sectors.Update(vm.Sector);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _uow.Sectors.ExistsAsync(vm.Sector.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(vm);
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _uow.Sectors
                .FirstOrDefaultAsync(id.Value);

            return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Sectors.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
