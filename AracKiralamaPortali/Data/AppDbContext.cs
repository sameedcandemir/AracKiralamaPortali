using AracKiralamaPortali.Models;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Kategori> Kategoriler { get; set; } = default!;
    public DbSet<Sube> Subeler { get; set; } = default!;
}
