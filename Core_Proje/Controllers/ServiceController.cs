using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        
        public IActionResult Index()
        {

            var serviceList = serviceManager.TGetList();
            return View(serviceList);
        }
        [HttpGet]
        public IActionResult AddService()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var removeService = serviceManager.TGetByID(id);
            serviceManager.TDelete(removeService);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {

            ViewBag.d1 = "Hizmet Düzenleme";
            ViewBag.d2 = "Hizmetlerim";
            ViewBag.d3 = "Hizmet Düzenleme";
            var values = serviceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
