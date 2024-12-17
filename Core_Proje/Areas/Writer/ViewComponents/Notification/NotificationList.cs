using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents.Notification
{
    [Area("Writer")]

    public class NotificationList : ViewComponent
    {

        private readonly IAnnouncementService _announcementService;

        public NotificationList(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetList().Take(5).ToList();
            return View(values);
        }
    }

}
