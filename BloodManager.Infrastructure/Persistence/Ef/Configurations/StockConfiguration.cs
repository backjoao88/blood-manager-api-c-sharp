using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// EFCore configuration for table Stock
/// Inherits from <see cref="EfBaseConfiguration{TEntity}"/>
/// </summary>
public class StockConfiguration : EfBaseConfiguration<Stock>
{
    public override void Configure(EntityTypeBuilder<Stock> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Stock");
        builder.Property(o => o.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
        builder.Property(o => o.BloodType).IsRequired().HasColumnName("BloodType");
        builder.Property(o => o.BloodRhFactor).IsRequired().HasColumnName("BloodRhFactor");
        builder.Property(o => o.QuantityMl).IsRequired();
    }
}