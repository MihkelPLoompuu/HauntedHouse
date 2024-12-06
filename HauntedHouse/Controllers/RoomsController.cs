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
        private readonly IFileServices _fileServices;

        public RoomsController(HauntedHouseContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
