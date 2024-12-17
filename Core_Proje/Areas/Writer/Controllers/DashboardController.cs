using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //statistics
            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = context.Announcements.Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 = context.Skills.Count();


            string api = "d1c4e9a91a576f125b79edd0957918a6";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            // API'den veri çek
            XDocument document = XDocument.Load(connection);

            // Örneğin, sıcaklık verisini çekelim
            var temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            // Veriyi ViewBag ile görünüme taşı
            ViewBag.v5 = temperature;


            return View();
        }
    }
}
