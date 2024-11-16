using HauntedHouse.Core.Dto;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using HauntedHouse.Models.Hunters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HauntedHouse.Controllers
{
    public class HuntersController : Controller
    {
        private readonly HunterContext _context;
        private readonly IHuntersServices _huntersServices;
        private readonly IFileServices _fileServices;

        public HuntersController(HunterContext context, IHuntersServices huntersServices, IFileServices fileServices)
        {
            _context = context;
            _huntersServices = huntersServices;
            _fileServices = fileServices;
        }
        public IActionResult Index()
        {
            var resultingInventory = _context.Hunters
                .OrderByDescending(y => y.HunterLevel)
                .Select(x => new HunterIndexViewModel
                {
                    ID = x.ID,
                    HunterName = x.HunterName,
                    HunterLevel = x.HunterLevel,
                });
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            HunterCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HunterCreateViewModel vm)
        {
            var dto = new HunterDto()
            {
                HunterName = vm.HunterName,
                HunterHealth = 100,
                HunterXP = 0,
                HunterXPNextLevel = 100,
                HunterLevel = 0,
                HunterStatus = (Core.Dto.HunterStatus)vm.HunterStatus,
                PrimaryAttackName = vm.PrimaryAttackName,
                PrimaryAttackPower = vm.PrimaryAttackPower,
                SecondaryAttackName = vm.SecondaryAttackName,
                SecondaryAttackPower = vm.SecondaryAttackPower,
                SpecialAttackName = vm.SpecialAttackName,
                SpecialAttackPower = vm.SpecialAttackPower,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    HunterID = x.HunterID,
                }).ToArray()
            };
            var result = await _huntersServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var hunter = await _huntersServices.DetailsAsync(id);

            if (hunter == null)
            {
                return NotFound();
            }

            var images = await _context.FileToDatabase
                .Where(t => t.HunterID == id)
                .Select(y => new HunterImageViewModel
                {
                    HunterID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new HunterDetailsViewModel();
            vm.ID = hunter.ID;
            vm.HunterName = hunter.HunterName;
            vm.HunterHealth = hunter.HunterHealth;
            vm.HunterXP = hunter.HunterXP;
            vm.HunterLevel = hunter.HunterLevel;
            vm.PrimaryAttackName = hunter.PrimaryAttackName;
            vm.PrimaryAttackPower = hunter.PrimaryAttackPower;
            vm.SecondaryAttackName = hunter.SecondaryAttackName;
            vm.SecondaryAttackPower = hunter.SecondaryAttackPower;
            vm.SpecialAttackName = hunter.SpecialAttackName;
            vm.SpecialAttackPower = hunter.SpecialAttackPower;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var hunter = await _huntersServices.DetailsAsync(id);

            if (hunter == null) { return NotFound(); }

            var images = await _context.FileToDatabase
                .Where(x => x.HunterID == id)
                .Select(y => new HunterImageViewModel
                {
                    HunterID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new HunterCreateViewModel();
            vm.ID = hunter.ID;
            vm.HunterName = hunter.HunterName;
            vm.HunterHealth = hunter.HunterHealth;
            vm.HunterXP = hunter.HunterXP;
            vm.HunterXPNextLevel = hunter.HunterXPNextLevel;
            vm.HunterLevel = hunter.HunterLevel;
            vm.PrimaryAttackName = hunter.PrimaryAttackName;
            vm.PrimaryAttackPower = hunter.PrimaryAttackPower;
            vm.SecondaryAttackName = hunter.SecondaryAttackName;
            vm.SecondaryAttackPower = hunter.SecondaryAttackPower;
            vm.SpecialAttackName = hunter.SpecialAttackName;
            vm.SpecialAttackPower = hunter.SpecialAttackPower;
            vm.CreatedAt = hunter.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(HunterCreateViewModel vm)
        {
            var dto = new HunterDto()
            {
                ID = (Guid)vm.ID,
                HunterName = vm.HunterName,
                HunterHealth = 100,
                HunterXP = 0,
                HunterXPNextLevel = 100,
                HunterLevel = 0,
                HunterStatus = (Core.Dto.HunterStatus)vm.HunterStatus,
                PrimaryAttackName = vm.PrimaryAttackName,
                PrimaryAttackPower = vm.PrimaryAttackPower,
                SecondaryAttackName = vm.SecondaryAttackName,
                SecondaryAttackPower = vm.SecondaryAttackPower,
                SpecialAttackName = vm.SpecialAttackName,
                SpecialAttackPower = vm.SpecialAttackPower,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    HunterID = x.HunterID,
                }).ToArray()
            };
            var result = await _huntersServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var hunter = await _huntersServices.DetailsAsync(id);

            if (hunter == null) { return NotFound(); };

            var images = await _context.FileToDatabase
                .Where(x => x.HunterID == id)
                .Select(y => new HunterImageViewModel
                {
                    HunterID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new HunterDeleteViewModel();

            vm.ID = hunter.ID;
            vm.HunterName = hunter.HunterName;
            vm.HunterHealth = hunter.HunterHealth;
            vm.HunterXP = hunter.HunterXP;
            vm.HunterXPNextLevel = hunter.HunterXPNextLevel;
            vm.HunterLevel = hunter.HunterLevel;
            vm.PrimaryAttackName = hunter.PrimaryAttackName;
            vm.PrimaryAttackPower = hunter.PrimaryAttackPower;
            vm.SecondaryAttackName = hunter.SecondaryAttackName;
            vm.SecondaryAttackPower = hunter.SecondaryAttackPower;
            vm.SpecialAttackName = hunter.SpecialAttackName;
            vm.SpecialAttackPower = hunter.SpecialAttackPower;
            vm.CreatedAt = hunter.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var hunterToDelete = await _huntersServices.Delete(id);

            if (hunterToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(HunterImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }
}
