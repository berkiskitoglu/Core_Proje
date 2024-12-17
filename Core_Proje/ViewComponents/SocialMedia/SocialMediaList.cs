using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        private ISocialMediaService _socialMediaService;

        public SocialMediaList(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.TGetList();
            return View(values);
        }
    }
}
