using Microsoft.AspNetCore.Mvc;

namespace HauntedHouse.Controllers
{
    public class AdminAreasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
