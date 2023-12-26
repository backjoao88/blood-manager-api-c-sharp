using Core.Entities;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// EFCore configuration for table Donor.
/// </summary>
public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("tbl_Donor");
        builder.HasKey(o => o.Id);
        builder.OwnsOne<Address>(o => o.Address, a =>
        {
            a.Property(o => o.Street).IsRequired();
            a.Property(o => o.City).IsRequired();
            a.Property(o => o.State).IsRequired();
            a.Property(o => o.PostalCode).IsRequired();
        });
        builder.OwnsOne<Email>(o => o.Email, a =>
        {
            a.Property(o => o.Value).IsRequired();
        });
        builder.Property(o => o.FirstName).IsRequired();
        builder.Property(o => o.LastName).IsRequired();
        builder.Property(o => o.Birth).IsRequired();
    }
}