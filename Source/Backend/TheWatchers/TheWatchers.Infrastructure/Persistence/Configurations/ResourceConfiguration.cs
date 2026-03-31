using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatchers.Domain.Entities;
using TheWatchers.Infrastructure.Persistence.Configurations.Common;

namespace TheWatchers.Infrastructure.Persistence.Configurations;

internal class ResourceConfiguration : EntityConfiguration<Resource>
{
    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        base.Configure(builder);

        // Set configuration for entity
        builder.ToTable("Resource", "dbo");

        // Set key for entity
        builder.HasKey(p => p.Id);

        // Set identity for entity (auto increment)
        builder.Property(p => p.Id).UseIdentityColumn();

        // Set configuration for columns
        builder.Property(p => p.Id).HasColumnType("smallint").IsRequired();
        builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100);
        builder.Property(p => p.ResourceCategoryId).HasColumnType("smallint");

        // Add configuration for foreign keys

        builder
            .HasOne(p => p.ResourceCategory)
            .WithMany(b => b.Resources)
            .HasForeignKey(p => p.ResourceCategoryId)
            .HasConstraintName("FK_dbo_Resource_ResourceCategoryId_dbo_ResourceCategory");
    }
}
