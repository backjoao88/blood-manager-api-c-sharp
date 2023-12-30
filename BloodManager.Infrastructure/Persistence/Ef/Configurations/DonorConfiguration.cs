using Core.Entities;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// EFCore configuration for table Donor.
/// Inherits from <see cref="EfBaseConfiguration{TEntity}"/>
/// </summary>
public class DonorConfiguration : EfBaseConfiguration<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Donor");
        builder.OwnsOne<Address>(o => o.Address, a =>
        {
            a.Property(o => o.Street).IsRequired().HasColumnName("Street");
            a.Property(o => o.City).IsRequired().HasColumnName("City");
            a.Property(o => o.State).IsRequired().HasColumnName("State");
            a.Property(o => o.PostalCode).IsRequired().HasColumnName("PostalCode");
        });
        builder.OwnsOne<Email>(o => o.Email, a =>
        {
            a.Property(o => o.Value).IsRequired().HasColumnName("Email");
        });
        builder.Property(o => o.FirstName).IsRequired().HasColumnName("FirstName");
        builder.Property(o => o.LastName).IsRequired().HasColumnName("LastName");
        builder.Property(o => o.Birth).IsRequired().HasColumnName("Birth");
        builder.Property(o => o.BloodType).IsRequired().HasColumnName("BloodType");
        builder.Property(o => o.EBloodRhFactor).IsRequired().HasColumnName("BloodRhFactor");
    }
}