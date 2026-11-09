using AracKiralamaPortali.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AracKiralamaPortali.Controllers;

public class HesapController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager) : Controller
{
    [HttpGet]
    public IActionResult Kayit()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Kayit(KayitViewModel model)
    {
        if (model.EhliyetTarihi > DateOnly.FromDateTime(DateTime.Today))
        {
            ModelState.AddModelError(nameof(model.EhliyetTarihi), "Ehliyet tarihi ileri bir tarih olamaz.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var kullanici = new Kullanici
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.Telefon,
            Ad = model.Ad,
            Soyad = model.Soyad,
            EhliyetTarihi = model.EhliyetTarihi
        };

        var sonuc = await userManager.CreateAsync(kullanici, model.Sifre);

        if (!sonuc.Succeeded)
        {
            // Kullanıcı adı e-posta olduğu için aynı mesaj iki kez gelebilir, Distinct bunu önler.
            foreach (var hata in sonuc.Errors.Select(e => e.Description).Distinct())
            {
                ModelState.AddModelError(string.Empty, hata);
            }

            return View(model);
        }

        await userManager.AddToRoleAsync(kullanici, "Musteri");
        await signInManager.SignInAsync(kullanici, isPersistent: false);

        TempData["Mesaj"] = "Hesabınız oluşturuldu. Hoş geldiniz!";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Giris(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Giris(GirisViewModel model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var sonuc = await signInManager.PasswordSignInAsync(model.Email, model.Sifre, model.BeniHatirla, lockoutOnFailure: true);

        if (sonuc.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Çok fazla hatalı deneme yapıldı. Lütfen birkaç dakika sonra tekrar deneyin.");
            return View(model);
        }

        if (!sonuc.Succeeded)
        {
            // Hangisinin yanlış olduğunu söylemiyoruz; böylece kayıtlı e-postalar öğrenilemez.
            ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı.");
            return View(model);
        }

        // Yalnızca kendi sitemizdeki adreslere dönüyoruz (açık yönlendirme saldırısına karşı).
        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cikis()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
