using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VasNazevProjektu.Controllers
{
    public class BmiController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new BmiModel());
        }

        [HttpPost]
        public IActionResult Index(BmiModel model)
        {
            if (ModelState.IsValid)
            {
                model.VypocitejBmi();
            }
            return View(model);
        }
    }
}