using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        IWriterMessageService _writerMessageService;

        public MessageController(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListSenderMessage(p);
            return View(messageList);
        }
       
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            return View(values);
        }
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            var values = _writerMessageService.TGetByID(id);
            return View(values);
        }
        [Route("")]
        [Route("SendMessage")]
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.Sender = mail;
            writerMessage.SenderName = name;
            Context context = new Context();
            var usernamesurname = context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + "" + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(writerMessage);
            return RedirectToAction("SenderMessage");
        }
    }
}
