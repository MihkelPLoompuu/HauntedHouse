using HauntedHouse.Core.Domain;
using HauntedHouse.Core.Dto;
using HauntedHouse.Data;
using HauntedHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HauntedHouse.Controllers
{
    public class PlayerProfileController : Controller
    {
        private readonly HauntedHouseContext _context;

        public PlayerProfileController(HauntedHouseContext context)
        {
            _context = context;
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_context.PlayerProfiles.OrderByDescending(x => x.ScreenName));
        }

        [HttpGet]
        public async Task<IActionResult> NewProfile()
        {
            return View();
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> NewProfile(PlayerProfileDto dto)
        {
            if (dto.ApplicationUserID == null)
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var newprofile = new PlayerProfile()
            {
                ID = dto.ID,
                ApplicationUserID = dto.ApplicationUserID,
                ScreenName = "",
                HunterCredits = 100,
                Victories = 0,
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileAttributedToAnAccountUserAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            var result = await _context.PlayerProfiles.AddAsync(newprofile);
            if (result != null)
            {

                return View("Index");
            }

            return View("~/Views/Home/Index.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> NewPlayerProfile()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<Player>

        //[HttpGet]
        //method to generate new playerprofile, info is gotten from a view
        // thet the player is directed to, rightt after confirmation.
    }
}
