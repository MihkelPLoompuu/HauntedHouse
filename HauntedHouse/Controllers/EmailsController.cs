using HauntedHouse.Core.Dto;
using HauntedHouse.Models.Emails;
using Microsoft.AspNetCore.Mvc;

namespace HauntedHouse.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices _emailsServices;
        public EmailsController(IEmailServices emailsServices)
        {
            _emailsServices = emailsServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel) 
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailsServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
