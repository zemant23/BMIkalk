using _06_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _06_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BmiModel novyModel = new BmiModel();

            return View(novyModel);
        }
    }
}
