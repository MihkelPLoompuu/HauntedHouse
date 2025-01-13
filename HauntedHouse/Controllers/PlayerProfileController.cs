using HauntedHouse.Data;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index()
        {
            return View( _context.PlayerProfiles.OrderByDescending(x => x.ScreenName));
        }
        //[HttpGet]
        //public async Task<Player>

        //[HttpGet]
        //method to generate new playerprofile, info is gotten from a view
        // thet the player is directed to, rightt after confirmation.
    }
}
