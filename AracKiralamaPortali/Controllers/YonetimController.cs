using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralamaPortali.Controllers;

[Authorize(Roles = "Admin")]
public class YonetimController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
