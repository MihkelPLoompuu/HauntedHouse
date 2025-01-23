using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Buildings;
using HauntedHouse.Models.Hunters;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Create()
        {
            ViewData["userHasSelected"] = new List<string>();
            BuildingCreateViewModel vm = new();
            var allRooms = _context.Rooms
                .OrderByDescending(y => y.RoomType)
                .Select(x => new RoomIndexViewModel
                {
                    ID = x.ID,
                    RoomName = x.RoomName,
                    RoomType = x.RoomType,
                    BuildingID = x.BuildingID,                    
                });

            vm.Rooms = allRooms.ToList();
            ViewData["allRooms"] = new SelectList(allRooms, "ID", "RoomName", allRooms);
            return View("BuildingCreate", vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuildingCreateViewModel vm, List<string> userHasSelected, List<Rooms> rooms)
        {
            List<Guid> tempParse = new();
            foreach (var stringID in userHasSelected)
            {
                tempParse.Add(Guid.Parse(stringID));
            }
            ViewData["userHasSelected"] = tempParse;

            var dto = new BuildingDto() { };
            dto.BuildingName = vm.BuildingName;
            dto.BuildingType = vm.BuildingType;
            dto.RoomIDs = tempParse;
            dto.Rooms = rooms; 
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;
            if (dto.Rooms == null || dto.Rooms.Count()! > 0) 
            {
                await Console.Out.WriteLineAsync("rooms null");
                await Console.Out.WriteLineAsync("idcount" + dto.RoomIDs.Count().ToString());
            }
            if (dto.RoomIDs == null || dto.RoomIDs.Count()! > 0) 
            {
                await Console.Out.WriteLineAsync("ids null"); 
                await Console.Out.WriteLineAsync("roomscount" + dto.Rooms.Count().ToString());
            }
            
            if (dto.Rooms != null && dto.RoomIDs.Any())
            {
                dto.Rooms = await IdToRoom(dto.RoomIDs);
            }
            
            else if (!dto.RoomIDs.Any() && dto.Rooms.Any())
            {
                dto.RoomIDs = await RoomToID(dto.Rooms);
            }
            rooms = dto.Rooms;

            var newSystem = await _services.Create(dto, rooms);
            if (newSystem == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
        private async Task<List<Rooms>> IdToPlanet(List<Guid> astralBodyIDs)
        {
            var result = new List<AstralBody>();
            foreach (var id in astralBodyIDs)
            {
                result.Add(await _astralBodiesServices.DetailsAsync(id));
            }
            return result;
        }
    }
}
