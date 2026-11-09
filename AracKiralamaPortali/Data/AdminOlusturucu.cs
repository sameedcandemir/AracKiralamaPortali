using AracKiralamaPortali.Models;
using Microsoft.AspNetCore.Identity;

namespace AracKiralamaPortali.Data;

public static class AdminOlusturucu
{
    public static async Task OlusturAsync(IServiceProvider servisler)
    {
        using var scope = servisler.CreateScope();
        var ayarlar = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();
        var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("AdminOlusturucu");

        // Bilgiler user-secrets'tan okunur; şifre depoya girmez.
        var email = ayarlar["BaslangicAdmin:Email"];
        var sifre = ayarlar["BaslangicAdmin:Sifre"];

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
        {
            logger.LogWarning("Başlangıç admin bilgileri bulunamadı, admin hesabı oluşturulmadı. README'ye bakın.");
            return;
        }

        if (await userManager.FindByEmailAsync(email) != null)
        {
            return;
        }

        var admin = new Kullanici
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            Ad = "Sistem",
            Soyad = "Yöneticisi"
        };

        var sonuc = await userManager.CreateAsync(admin, sifre);

        if (!sonuc.Succeeded)
        {
            logger.LogError("Admin hesabı oluşturulamadı: {Hatalar}", string.Join(" ", sonuc.Errors.Select(e => e.Description)));
            return;
        }

        await userManager.AddToRoleAsync(admin, "Admin");
    }
}
