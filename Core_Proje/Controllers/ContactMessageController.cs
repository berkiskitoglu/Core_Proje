using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.TGetList();
            return View(values);
        }
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult MessageDetails(int id)
        {
            var values = _messageService.TGetByID(id);
            return View(values);
        }
    }
}
