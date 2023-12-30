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
    public DbSet<Stock> Stocks { get; set; } = null!;
    public DbSet<Donation> Donations { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DonorConfiguration());
        modelBuilder.ApplyConfiguration(new StockConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-N7P7NAN\\SQLEXPRESS01;User=sa;Database=donation-db;Password=joao#123;TrustServerCertificate=true;");
    }
}