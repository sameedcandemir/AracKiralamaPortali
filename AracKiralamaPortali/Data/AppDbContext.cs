using AracKiralamaPortali.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Kullanici>(options)
{
    public DbSet<Kategori> Kategoriler { get; set; } = default!;
    public DbSet<Sube> Subeler { get; set; } = default!;
    public DbSet<Arac> Araclar { get; set; } = default!;
    public DbSet<Rezervasyon> Rezervasyonlar { get; set; } = default!;
    public DbSet<BakimKaydi> BakimKayitlari { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "a1f4c2d0-5b7e-4c11-9d3a-0e6f1b2c3d41",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "b2e5d3c1-6c8f-4d22-8e4b-1f7a2c3d4e52"
            },
            new IdentityRole
            {
                Id = "c3a6e4d2-7d9a-4e33-9f5c-2a8b3d4e5f63",
                Name = "Musteri",
                NormalizedName = "MUSTERI",
                ConcurrencyStamp = "d4b7f5e3-8eab-4f44-a06d-3b9c4e5f6a74"
            });

        modelBuilder.Entity<Kategori>().HasData(
            new Kategori { Id = 1, Ad = "Ekonomi", Aciklama = "Düşük yakıt tüketimli, şehir içi kullanıma uygun araçlar" },
            new Kategori { Id = 2, Ad = "SUV", Aciklama = "Geniş iç hacimli, uzun yol ve aile kullanımına uygun araçlar" },
            new Kategori { Id = 3, Ad = "Lüks", Aciklama = "Üst segment konfor ve donanıma sahip araçlar" });

        modelBuilder.Entity<Sube>().HasData(
            new Sube { Id = 1, Ad = "Kadıköy Şubesi", Sehir = "İstanbul", Adres = "Caferağa Mah. Moda Cad. No: 10 Kadıköy", Telefon = "02160000001" },
            new Sube { Id = 2, Ad = "Çankaya Şubesi", Sehir = "Ankara", Adres = "Kızılay Mah. Atatürk Bulvarı No: 20 Çankaya", Telefon = "03120000002" },
            new Sube { Id = 3, Ad = "Konak Şubesi", Sehir = "İzmir", Adres = "Alsancak Mah. Kıbrıs Şehitleri Cad. No: 30 Konak", Telefon = "02320000003" });

        modelBuilder.Entity<Arac>().HasData(
            new Arac { Id = 1, Marka = "Renault", Model = "Clio", Yil = 2023, Plaka = "34 ABC 101", YakitTuru = "Benzin", Vites = "Manuel", GunlukUcret = 1200, KategoriId = 1, SubeId = 1 },
            new Arac { Id = 2, Marka = "Fiat", Model = "Egea", Yil = 2022, Plaka = "06 DEF 202", YakitTuru = "Dizel", Vites = "Manuel", GunlukUcret = 1100, KategoriId = 1, SubeId = 2 },
            new Arac { Id = 3, Marka = "Dacia", Model = "Duster", Yil = 2023, Plaka = "35 GHI 303", YakitTuru = "Dizel", Vites = "Otomatik", GunlukUcret = 1800, KategoriId = 2, SubeId = 3 },
            new Arac { Id = 4, Marka = "Hyundai", Model = "Tucson", Yil = 2024, Plaka = "34 JKL 404", YakitTuru = "Hibrit", Vites = "Otomatik", GunlukUcret = 2500, KategoriId = 2, SubeId = 1 },
            new Arac { Id = 5, Marka = "BMW", Model = "520i", Yil = 2024, Plaka = "06 MNO 505", YakitTuru = "Benzin", Vites = "Otomatik", GunlukUcret = 5000, KategoriId = 3, SubeId = 2, Durum = AracDurumu.Bakimda });

        modelBuilder.Entity<BakimKaydi>().HasData(
            new BakimKaydi { Id = 1, AracId = 1, Tarih = new DateOnly(2026, 9, 15), BakimTuru = "Periyodik Bakım", Aciklama = "Yağ ve filtre değişimi", Maliyet = 3500 },
            new BakimKaydi { Id = 2, AracId = 5, Tarih = new DateOnly(2026, 11, 2), BakimTuru = "Lastik Değişimi", Aciklama = "Dört lastik kışlık lastikle değiştirildi", Maliyet = 18000 });

        modelBuilder.Entity<Arac>()
            .HasIndex(a => a.Plaka)
            .IsUnique();

        modelBuilder.Entity<Arac>()
            .HasOne(a => a.Kategori)
            .WithMany(k => k.Araclar)
            .HasForeignKey(a => a.KategoriId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Arac>()
            .HasOne(a => a.Sube)
            .WithMany(s => s.Araclar)
            .HasForeignKey(a => a.SubeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BakimKaydi>()
            .HasOne(b => b.Arac)
            .WithMany(a => a.BakimKayitlari)
            .HasForeignKey(b => b.AracId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rezervasyon>()
            .HasOne(r => r.Kullanici)
            .WithMany(k => k.Rezervasyonlar)
            .HasForeignKey(r => r.KullaniciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rezervasyon>()
            .HasOne(r => r.Arac)
            .WithMany(a => a.Rezervasyonlar)
            .HasForeignKey(r => r.AracId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rezervasyon>()
            .HasOne(r => r.AlisSube)
            .WithMany()
            .HasForeignKey(r => r.AlisSubeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rezervasyon>()
            .HasOne(r => r.IadeSube)
            .WithMany()
            .HasForeignKey(r => r.IadeSubeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
