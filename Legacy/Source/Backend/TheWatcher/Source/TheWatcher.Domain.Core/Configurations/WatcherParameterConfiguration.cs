using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Configurations.Common;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
    internal class WatcherParameterConfiguration : EntityConfiguration<WatcherParameter>
	{
		public override void Configure(EntityTypeBuilder<WatcherParameter> builder)
		{
			base.Configure(builder);

			// Set configuration for entity
			builder.ToTable("WatcherParameter", "dbo");

			// Set key for entity
			builder.HasKey(p => p.Id);

			// Set identity for entity (auto increment)
			builder.Property(p => p.Id).UseIdentityColumn();

			// Set configuration for columns
			builder
				.Property(p => p.Id)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.WatcherId)
				.HasColumnType("smallint")
				.IsRequired()
				;

			builder
				.Property(p => p.Parameter)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired()
				;

			builder
				.Property(p => p.Value)
				.HasColumnType("nvarchar(max)")
				;

			builder
				.Property(p => p.IsDefault)
				.HasColumnType("bit")
				;

			builder
				.Property(p => p.Description)
				.HasColumnType("nvarchar(max)")
				;

			// Add configuration for uniques

			builder
				.HasIndex(p => new { p.WatcherId, p.Parameter })
				.IsUnique()
				.HasDatabaseName("UQ_dbo_WatcherParameter_WatcherId_Parameter")
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.WatcherFk)
				.WithMany(b => b.WatcherParameterList)
				.HasForeignKey(p => p.WatcherId)
				.HasConstraintName("FK_dbo_WatcherParameter_WatcherId_dbo_Watcher")
				;
		}
	}
}
