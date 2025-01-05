using Microsoft.AspNetCore.Mvc;

namespace HauntedHouse.Controllers
{
    public class BuildingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
