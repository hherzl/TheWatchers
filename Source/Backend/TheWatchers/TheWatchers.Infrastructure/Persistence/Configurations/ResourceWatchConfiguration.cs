using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence.Configurations.Common;

namespace TheWatchers.Infrastructure.Persistence.Configurations;

internal class ResourceWatchConfiguration : EntityConfiguration<ResourceWatch>
{
    public override void Configure(EntityTypeBuilder<ResourceWatch> builder)
    {
        base.Configure(builder);

        // Set configuration for entity
        builder.ToTable("ResourceWatch", "dbo");

        // Set key for entity
        builder.HasKey(p => p.Id);

        // Set identity for entity (auto increment)
        builder.Property(p => p.Id).UseIdentityColumn();

        // Set configuration for columns
        builder.Property(p => p.Id).HasColumnType("int").IsRequired();
        builder.Property(p => p.ResourceId).HasColumnType("smallint").IsRequired();
        builder.Property(p => p.EnvironmentId).HasColumnType("smallint").IsRequired();
        builder.Property(p => p.Interval).HasColumnType("int").IsRequired();
        builder.Property(p => p.Description).HasColumnType("nvarchar(max)");
        builder.Property(p => p.LastUpdateAt).HasColumnType("datetime");
        builder.Property(p => p.LastUpdateBy).HasColumnType("nvarchar").HasMaxLength(100);

        // Add configuration for uniques

        builder
            .HasIndex(p => new { p.ResourceId, p.EnvironmentId })
            .IsUnique()
            .HasDatabaseName("UQ_dbo_ResourceWatch_ResourceId_EnvironmentId");

        // Add configuration for foreign keys

        builder
            .HasOne(p => p.Resource)
            .WithMany(b => b.ResourceWatches)
            .HasForeignKey(p => p.ResourceId)
            .HasConstraintName("FK_dbo_ResourceWatch_ResourceId_dbo_Resource");

        builder
            .HasOne(p => p.Environment)
            .WithMany(b => b.ResourceWatches)
            .HasForeignKey(p => p.EnvironmentId)
            .HasConstraintName("FK_dbo_ResourceWatch_EnvironmentId_dbo_Environment");
    }
}
