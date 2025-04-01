namespace _06_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

public class BmiModel
{
    public double Vyska { get; set; } 
    public double Vaha { get; set; } 
    public double? BmiVysledek { get; set; }
    public string? BmiKategorie { get; set; }

    public void VypocitejBmi()
    {
        if (Vyska > 0 && Vaha > 0)
        {
            BmiVysledek = Vaha / (Vyska * Vyska);
            BmiKategorie = ZiskejKategorii(BmiVysledek.Value);
        }
    }

    private string ZiskejKategorii(double bmi)
    {
        if (bmi < 18.5) return "Podváha";
        if (bmi < 25) return "Normální váha";
        if (bmi < 30) return "Nadváha";
        if (bmi < 35) return "Obezita 1. stupně";
        if (bmi < 40) return "Obezita 2. stupně";
        return "Obezita 3. stupně";
    }
}

// Controller
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