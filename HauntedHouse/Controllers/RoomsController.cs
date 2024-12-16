using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Hunters;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace HauntedHouse.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HauntedHouseContext _context;
        private readonly IRoomsServices _roomsServices;
        private readonly IFileServices _fileServices;

        public RoomsController(HauntedHouseContext context, IFileServices fileServices, IRoomsServices roomsServices)
        {
            _context = context;
            _fileServices = fileServices;
            _roomsServices = roomsServices;
        }
        public IActionResult Index()
        {
            var allPlanets = _context.Rooms
               .OrderByDescending(y => y.RoomType)
               .Select(x => new RoomIndexViewModel
               {
                   ID = x.ID,
                   RoomName = x.RoomName,
                   RoomType = x.RoomType,
                   BuildingID = (Guid)x.BuildingID,
               });
            return View(allPlanets);
        }
        [HttpGet]
        public IActionResult Create()
        {
            RoomCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateViewModel vm)
        {
            var dto = new RoomDto()
            {
                RoomName = vm.RoomName,
                RoomType =  vm.RoomType,
                BuildingID = vm.BuildingID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                }).ToArray()
            };
            var result = await _roomsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
