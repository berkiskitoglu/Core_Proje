using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutService.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            _aboutService.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
