using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Buildings;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HauntedHouse.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly HauntedHouseContext _context;
        public BuildingsController(HauntedHouseContext context)
        {
            _context = context;
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
    }
}
