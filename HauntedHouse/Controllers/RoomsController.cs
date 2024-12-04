using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace HauntedHouse.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HunterContext _context;
        private readonly IRoomsServices _roomsServices;
        private readonly IFileServices _fileServices;

        public RoomsController(HunterContext context, IRoomsServices roomsServices, IFileServices fileServices)
        {
            _context = context;
            _roomsServices = roomsServices;
            _fileServices = fileServices;
        }
        public IActionResult Index()
        {
            return View();
        }
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
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    RoomID = x.RoomID,
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
