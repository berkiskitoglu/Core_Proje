using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        private readonly IWriterMessageService _writerMessageService;

        public AdminNavbarMessageList(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        public IViewComponentResult Invoke()
        {
           
            string p = "admin@gmail.com";
            var values = _writerMessageService.GetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();
            return View(values);
        }
    }
}
