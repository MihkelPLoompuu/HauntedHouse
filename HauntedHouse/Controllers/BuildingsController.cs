using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Buildings;
using HauntedHouse.Models.Hunters;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HauntedHouse.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly HauntedHouseContext _context;
        private readonly IBuildingsServices _services;

        public BuildingsController(HauntedHouseContext context, IBuildingsServices services)
        {
            _context = context;
            _services = services;
        }
        public IActionResult Index()
        {
            var resultingInventory = _context.Buildings
                           .OrderByDescending(y => y.BuildingType)
                           .Select(x => new BuildingIndexViewModel
                           {
                               ID = x.ID,
                               BuildingName = x.BuildingName,
                               BuildingType = x.BuildingType,   
                           });
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            BuildingCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuildingCreateViewModel vm)
        {
            var dto = new BuildingDto()
            {
                BuildingName = vm.BuildingName,
                BuildingType = vm.BuildingType,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var result = await _services.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
