using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Hunters;
using HauntedHouse.Models.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var room = await _roomsServices.DetailsAsync(id);

            if (room == null) { return NotFound(); }

            var images = await _context.FileToDatabase
                .Where(x => x.ID == id)
                .Select(y => new RoomImageViewModel
                {
                   
                    RoomID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new RoomCreateViewModel();
            vm.ID = room.ID;
            vm.RoomName = room.RoomName;
            vm.RoomType = room.RoomType;          
            vm.CreatedAt = room.CreatedAt;
            vm.UpdatedAt = DateTime.Now;

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoomCreateViewModel vm)
        {
            var dto = new RoomDto()
            {
                ID = (Guid)vm.ID,
                RoomName = vm.RoomName,
                RoomType = vm.RoomType,                
                CreatedAt = vm.CreatedAt,
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
            var result = await _roomsServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var room = await _roomsServices.DetailsAsync(id);

            if (room == null) { return NotFound(); };

            var images = await _context.FileToDatabase
                .Where(x => x.ID == id)
                .Select(y => new RoomImageViewModel
                {
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new RoomDeleteViewModel();

            vm.ID = room.ID;
            vm.RoomName = room.RoomName; 
            vm.RoomType = room.RoomType;
            vm.CreatedAt = room.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var hunterToDelete = await _roomsServices.Delete(id);

            if (hunterToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }
    }
}
