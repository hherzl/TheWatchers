using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Configurations.Common;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
	internal class ResourceCategoryConfiguration : EntityConfiguration<ResourceCategory>
	{
		public override void Configure(EntityTypeBuilder<ResourceCategory> builder)
		{
			base.Configure(builder);

			// Set configuration for entity
			builder.ToTable("ResourceCategory", "dbo");

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
				.Property(p => p.Name)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired()
				;

			builder
				.Property(p => p.WatcherId)
				.HasColumnType("smallint")
				;

			// Add configuration for uniques

			builder
				.HasIndex(p => p.Name)
				.IsUnique()
				.HasDatabaseName("UQ_dbo_ResourceCategory_Name")
				;

			// Add configuration for foreign keys

			builder
				.HasOne(p => p.WatcherFk)
				.WithMany(b => b.ResourceCategoryList)
				.HasForeignKey(p => p.WatcherId)
				.HasConstraintName("FK_dbo_ResourceCategory_WatcherId_dbo_Watcher")
				;
		}
	}
}
