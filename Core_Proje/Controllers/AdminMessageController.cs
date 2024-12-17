using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService;

        public AdminMessageController(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageService.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageService.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            _writerMessageService.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "Admin";
            writerMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context context = new Context();
            var usernamesurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + "" + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
