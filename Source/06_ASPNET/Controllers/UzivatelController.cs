using Microsoft.AspNetCore.Mvc;
using _06_ASPNET.Models;
using _06_ASPNET.Data;

namespace _06_ASPNET.Controllers
{
    public class UzivatelController : Controller
    {
        private readonly MujContext _context;

        public UzivatelController(MujContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registrovat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrovat(string jmeno, string heslo, string heslo_kontrola)
        {
            ViewData["chyba"] = "";

            if (jmeno == null || jmeno.Length == 0)
                ViewData["chyba"] += "Jméno nebylo zadáno. ";
            if (heslo == null || heslo.Length == 0)
                ViewData["chyba"] += "Heslo nebylo zadáno. ";
            if(heslo != heslo_kontrola)
                ViewData["chyba"] += "Hesla se neshodují. ";

            Uzivatel? existujiciUzivatel = _context.
                Uzivatele.FirstOrDefault(u => u.Jmeno == jmeno);

            if (existujiciUzivatel != null)
                ViewData["chyba"] = "Uživatel s tímto jménem již existuje.";

            if (ViewData["chyba"] != "")
                return View();

            // nyni muzeme zacit se samotnou registraci
            heslo = BCrypt.Net.BCrypt.HashPassword(heslo);

            Uzivatel registrovanyUzivatel = new Uzivatel() { Jmeno = jmeno, Heslo = heslo };

            _context.Uzivatele.Add(registrovanyUzivatel);
            _context.SaveChanges();

            return RedirectToAction("Prihlasit");
        }

        [HttpGet]
        public IActionResult Prihlasit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Prihlasit(string jmeno, string heslo)
        {
            ViewData["chyba"] = "";

            if (jmeno == null || jmeno.Length == 0)
                ViewData["chyba"] += "Jméno nebylo zadáno. ";
            if (heslo == null || heslo.Length == 0)
                ViewData["chyba"] += "Heslo nebylo zadáno. ";

            Uzivatel? prihlasovanyUzivatel = _context.
                Uzivatele.FirstOrDefault(u => u.Jmeno == jmeno);

            if (prihlasovanyUzivatel == null)
                ViewData["chyba"] = "Chybně zadané jméno nebo heslo.";
            else if(!BCrypt.Net.BCrypt.Verify(heslo, prihlasovanyUzivatel.Heslo))
                ViewData["chyba"] = "Chybně zadané jméno nebo heslo.";

            if (ViewData["chyba"] != "")
                return View();

            // nyni lze uzivatele doopravdy prihlasit
            HttpContext.Session.SetInt32("PrihlasenyUzivatelId", prihlasovanyUzivatel.Id);

            return RedirectToAction("Profil");
        }

        public IActionResult Profil()
        {
            int? id = HttpContext.Session.GetInt32("PrihlasenyUzivatelId");

            if (id == null)
            {
                return RedirectToAction("Prihlasit");
            }

            // nacteni dat prihlaseneho uzivatele
            Uzivatel? prihlasenyUzivatel = _context
                .Uzivatele.Where(u => u.Id == id).FirstOrDefault();

            if(prihlasenyUzivatel == null)
            {
                return RedirectToAction("Registrovat");
            }

            return View(prihlasenyUzivatel);
        }

        [HttpPost]
        public IActionResult Odhlasit()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
