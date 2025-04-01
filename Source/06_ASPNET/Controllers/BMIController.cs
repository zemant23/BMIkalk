using Microsoft.AspNetCore.Mvc;
using _06_ASPNET.Models;

namespace _06_ASPNET.Controllers
{
    public class BmiController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Bmi/Index.cshtml", new BmiModel());
        }

        [HttpPost]
        public IActionResult Index(BmiModel model)
        {
            if (ModelState.IsValid)
            {
                model.VypocitejBmi();
            }
            return View("~/Views/Bmi/Index.cshtml", model);
        }
    }
}