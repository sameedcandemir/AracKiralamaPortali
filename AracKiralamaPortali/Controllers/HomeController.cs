using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AracKiralamaPortali.Models;

namespace AracKiralamaPortali.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Gizlilik()
    {
        return View();
    }

    // Beklenmeyen bir hata olduğunda (500) buraya yönlendirilir.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Hata()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // 404 gibi durum kodlarında gösterilir; kod adresten gelir (/Home/Durum/404).
    public IActionResult Durum(int id)
    {
        ViewData["Kod"] = id;
        return View();
    }
}
