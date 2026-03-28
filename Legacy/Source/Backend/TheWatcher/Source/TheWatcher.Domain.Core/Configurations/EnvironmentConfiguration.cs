using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Configurations.Common;
using Environment = TheWatcher.Domain.Core.Models.Environment;

namespace TheWatcher.Domain.Core.Configurations
{
    internal class EnvironmentConfiguration : EntityConfiguration<Environment>
	{
		public override void Configure(EntityTypeBuilder<Environment> builder)
		{
			base.Configure(builder);

			// Set configuration for entity
			builder.ToTable("Environment", "dbo");

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
		}
	}
}
