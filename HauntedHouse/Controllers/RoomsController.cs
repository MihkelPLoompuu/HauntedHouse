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

        public RoomsController(HauntedHouseContext context, IRoomsServices roomsServices, IFileServices fileServices)
        {
            _context = context;
            _roomsServices = roomsServices;
            _fileServices = fileServices;
        }
        public IActionResult Index()
        {
            var Room = _context.Rooms
               .OrderByDescending(y => y.RoomName)
               .Select(x => new RoomIndexViewModel
               {
                   ID = x.ID,
                   RoomName = x.RoomName,
                   RoomType = x.RoomType,
                   Image = (List<RoomImageViewModel>)_context.FileToDatabase
                      .Where(t => t.HunterID == x.ID)
                      .Select(z => new RoomImageViewModel
                      {
                          RoomID = z.ID,
                          ImageID = z.ID,
                          ImageData = z.ImageData,
                          ImageTitle = z.ImageTitle,
                          Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(z.ImageData))
                      })
               });
            return View(Room);
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
