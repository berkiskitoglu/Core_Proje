using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        private readonly IContactService _contactService;

        public ContactSubPlaceController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
