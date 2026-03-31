using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatchers.Infrastructure.Persistence.Configurations.Common;

using Env = TheWatchers.Domain.Entities.Environment;

namespace TheWatchers.Infrastructure.Persistence.Configurations;

internal class EnvironmentConfiguration : EntityConfiguration<Env>
{
    public override void Configure(EntityTypeBuilder<Env> builder)
    {
        base.Configure(builder);

        // Set configuration for entity
        builder.ToTable("Environment", "dbo");

        // Set key for entity
        builder.HasKey(p => p.Id);

        // Set identity for entity (auto increment)
        builder.Property(p => p.Id).UseIdentityColumn();

        // Set configuration for columns
        builder.Property(p => p.Id).HasColumnType("smallint").IsRequired();
        builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
    }
}
