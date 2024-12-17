using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        private readonly IExperienceService  _experienceService;

        public Experience2Controller(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(_experienceService.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            _experienceService.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }
        public IActionResult GetById(int ExprerienceID)
        {
            var v = _experienceService.TGetByID(ExprerienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var v = _experienceService.TGetByID(id);
            _experienceService.TDelete(v);
            return NoContent();
        }
        public IActionResult UpdateExperince(Experience p)
        {
            var v = _experienceService.TGetByID(p.ExperienceID);
            _experienceService.TUpdate(v);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
