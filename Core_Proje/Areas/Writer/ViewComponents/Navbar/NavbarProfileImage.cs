using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents.Navbar
{
    public class NavbarProfileImage : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarProfileImage(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageUrl;
            return View(values);
        }
    }
}
