using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult NavigationPartial()
        {
            return PartialView();
        }
        public PartialViewResult NewSidebar()
        {
            return PartialView();
        }
    }
}
