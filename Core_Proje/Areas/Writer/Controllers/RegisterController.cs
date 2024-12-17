using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core_Proje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if(ModelState.IsValid)
            {
                WriterUser writerUser = new WriterUser()
                {
                    Name = userRegisterViewModel.Name,
                    Surname = userRegisterViewModel.Surname,
                    UserName = userRegisterViewModel.UserName,
                    Email = userRegisterViewModel.Mail,
                    ImageUrl = userRegisterViewModel.ImageUrl
                };
              
                if(userRegisterViewModel.ConfirmPassword == userRegisterViewModel.Password)
                {
                    var result = await _userManager.CreateAsync(writerUser, userRegisterViewModel.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }
                         
            }
            
            return View();
        }
    }
}
