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
