using Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManager.Infrastructure.Persistence.Ef.Configurations;

/// <summary>
/// Base configuration for EFCore configurations
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class EfBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Specify a primary key 'ID' for all derived configurations
    /// </summary>
    /// <param name="builder"></param>
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
    }
}