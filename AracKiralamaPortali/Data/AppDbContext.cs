using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
