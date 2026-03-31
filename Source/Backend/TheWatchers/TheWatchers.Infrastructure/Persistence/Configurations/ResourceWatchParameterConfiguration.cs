using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence.Configurations.Common;

namespace TheWatchers.Infrastructure.Persistence.Configurations;

internal class ResourceWatchParameterConfiguration : EntityConfiguration<ResourceWatchParameter>
{
    public override void Configure(EntityTypeBuilder<ResourceWatchParameter> builder)
    {
        base.Configure(builder);

        // Set configuration for entity
        builder.ToTable("ResourceWatchParameter", "dbo");

        // Set key for entity
        builder.HasKey(p => p.Id);

        // Set identity for entity (auto increment)
        builder.Property(p => p.Id).UseIdentityColumn();

        // Set configuration for columns
        builder.Property(p => p.Id).HasColumnType("int").IsRequired();
        builder.Property(p => p.ResourceWatchId).HasColumnType("int").IsRequired();
        builder.Property(p => p.Parameter).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        builder.Property(p => p.Value).HasColumnType("nvarchar(max)");
        builder.Property(p => p.Description).HasColumnType("nvarchar(max)");

        // Add configuration for uniques

        builder
            .HasIndex(p => new { p.ResourceWatchId, p.Parameter })
            .IsUnique()
            .HasDatabaseName("UQ_dbo_ResourceWatchParameter_ResourceWatchId_Parameter");

        // Add configuration for foreign keys

        builder
            .HasOne(p => p.ResourceWatch)
            .WithMany(b => b.ResourceWatchParameters)
            .HasForeignKey(p => p.ResourceWatchId)
            .HasConstraintName("FK_dbo_ResourceWatchParameter_ResourceWatchId_dbo_ResourceWatch");
    }
}
