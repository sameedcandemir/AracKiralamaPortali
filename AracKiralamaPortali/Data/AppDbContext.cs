using AracKiralamaPortali.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Kullanici>(options)
{
    public DbSet<Kategori> Kategoriler { get; set; } = default!;
    public DbSet<Sube> Subeler { get; set; } = default!;
    public DbSet<Arac> Araclar { get; set; } = default!;
    public DbSet<Rezervasyon> Rezervasyonlar { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
