using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {

            var portfolioList = portfolioManager.TGetList();
            return View(portfolioList);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            ModelState.Clear();       
            portfolio.Status = true;

            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult result = validationRules.Validate(portfolio);
            if(result.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        public IActionResult DeletePortfolio(int id)
        {
            var deletePortfolio = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(deletePortfolio);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {

            ViewBag.d1 = "Düzenleme";
            ViewBag.d2 = "Yetenekler";
            ViewBag.d3 = "Yetenek Düzenleme";
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult result = validationRules.Validate(portfolio);
            if(result.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
