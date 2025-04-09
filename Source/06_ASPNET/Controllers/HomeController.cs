using _06_ASPNET.Data;
using _06_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _06_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly MujContext _context;

        public HomeController(MujContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BMI novyModel = _context.BmiModely.FirstOrDefault();

            return View(novyModel);
        }
    }
}
