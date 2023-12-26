using BloodManager.Infrastructure.Persistence.Ef.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.Ef;

/// <summary>
/// Class that represents an DbContext from EFCore.
/// </summary>
public class EfCoreContext : DbContext
{
    public DbSet<Donor> Donors { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DonorConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-N7P7NAN\\SQLEXPRESS01;User=sa;Database=donation-db;Password=joao#123;TrustServerCertificate=true;");
    }
}