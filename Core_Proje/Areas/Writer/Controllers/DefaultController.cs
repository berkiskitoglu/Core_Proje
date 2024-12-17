using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public DefaultController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values =   _announcementService.TGetList();
            return View(values);
        }

        public IActionResult AnnouncementDetails(int id)
        {
            var values = _announcementService.TGetByID(id);
            return View(values);
        }

    }
}
