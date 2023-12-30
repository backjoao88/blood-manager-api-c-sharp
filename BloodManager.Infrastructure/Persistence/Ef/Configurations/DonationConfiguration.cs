using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// EFCore configuration for table Donation
/// Inherits from <see cref="EfBaseConfiguration{TEntity}"/>
/// </summary>
public class DonationConfiguration : EfBaseConfiguration<Donation>
{
    public override void Configure(EntityTypeBuilder<Donation> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Donation");
        builder.HasOne<Donor>(o => o.Donor).WithMany().HasForeignKey(o => o.IdDonor).OnDelete(DeleteBehavior.SetNull);
        builder.Property(o => o.IdDonor).IsRequired(false);
        builder.Property(o => o.QuantityMl).IsRequired().HasColumnName("QuantityMl");
        builder.Property(o => o.DonationDate).IsRequired().HasColumnType("datetime");
    }
}